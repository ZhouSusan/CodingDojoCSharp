using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;
using GlobalATM.Models;

namespace GlobalATM.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private MyContext db;
        
        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View("Index");
        }

        [HttpPost("register")]
        public IActionResult Register(User newUser, string AccountType, string CardNumber, string AccountNumber)
        {
            if (ModelState.IsValid) 
            {
                if (db.Users.Any(u=> u.Email == newUser.Email)) 
                {
                    ModelState.AddModelError("Email", "Email is already in use");
                    return View("Index");
                }
                PasswordHasher<User> Hasher =  new PasswordHasher<User>();
                //Hash the password only after verifying that everything else is good to go
                newUser.Pin = Hasher.HashPassword(newUser, newUser.Pin);
                if (AccountType == "Checking")
                {
                    Checking account = new Checking();
                    account.CardNumber = CardNumber;
                    newUser.Accounts.Add(account);
                    HttpContext.Session.SetString("CardNumber", CardNumber);
                }
                else 
                {
                    Saving account = new Saving();
                    account.InterestRate = .05;
                    account.AccountNumber = AccountNumber;
                    newUser.Accounts.Add(account);
                    HttpContext.Session.SetString("AccountNumber", AccountNumber);
                }
                db.Add(newUser);
                db.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return RedirectToAction("Success");
            }

            return View("Index");
        }

        [HttpGet("Login")]
        public IActionResult LogIn()
        {
            return View("LogIn");
        }

        [HttpPost("Login")]
        public IActionResult Login(LogUser logUser)
        {
            if (ModelState.IsValid)
            {
                Account account = db.Accounts
                                    .Include(a => a.User).
                                        FirstOrDefault(u => u.AccountNumber == logUser.LoginAccountNum);
                Account checkingAccount = db.Checkings
                                            .Include(u => u.User)
                                                .FirstOrDefault(u => u.CardNumber == logUser.LoginAccountNum);
                if (checkingAccount == null)
                {
                    ModelState.AddModelError("LoginAccountNum", "Invalid login attempt");
                    return View("Login");
                }
                //check if password is correct
                PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
                PasswordVerificationResult result = Hasher.VerifyHashedPassword(logUser, checkingAccount.User.Pin, logUser.LoginPin); 
                //When the vertifcation runs, it will passed 1(successfully) or 0(password is incorrect)
                if (result == 0)
                {
                    ModelState.AddModelError("LoginPin", "Invalid login attempt");
                    return View("Login");
                }

                HttpContext.Session.SetInt32("UserId", checkingAccount.User.UserId);

                return RedirectToAction("Success");
            }
            return View("Login");
        }

        [HttpGet("/transactions")]
        public IActionResult Transactions()
        {
            User currentUser =  db.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
                Account userAccount = db.Accounts.Include("Transactions").FirstOrDefault(a => a.AccountNumber == HttpContext.Session.GetString("AccountNumber"));
                if (userAccount.Transactions != null)
                {
                    userAccount.Transactions = db.Transactions.
                    OrderByDescending(c=>c.CreatedAt)
                    .ToList();
                }
                ViewBag.CurrentUser = currentUser;
                ViewBag.UserAccount = userAccount; 
            return View("Transactions");
        }

        [HttpPost("Withdrawal")]
        public IActionResult Withdrawal(double amount, LogUser user)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                User currentUser =  db.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
                Account userAccount = db.Accounts.Include("Transactions").FirstOrDefault(t => t.User.UserId ==  HttpContext.Session.GetInt32("UserId"));
                if (userAccount.Transactions != null)
                {
                    userAccount.Transactions = db.Transactions.
                    OrderByDescending(c=>c.CreatedAt)
                    .ToList();
                }
                ViewBag.CurrentUser = currentUser;
                ViewBag.UserAccount = userAccount; 
                //
                if (amount > 0)
                {
                    //Create a new isntance of an object of transaction
                    Transaction newTrans = new Transaction {
                        Amount = amount,
                        CreatedAt = DateTime.Now,
                        UserId = currentUser.UserId
                    };
                userAccount.Transactions.Add(newTrans);
                db.SaveChanges();
                return Redirect("Transactions");
                }
                else if (amount + userAccount.Balance < 0)
                {
                    ModelState.AddModelError("Amount", "Insufficient funds");
                    return View("Transactions");
                }
                else 
                {
                    Transaction newTrans = new Transaction {
                        Amount = amount,
                        CreatedAt = DateTime.Now,
                        UserId = currentUser.UserId
                    };
                userAccount.Transactions.Add(newTrans);
                db.SaveChanges();
                    return Redirect("Transactions");
                }
            }

            return View("Index");
        }

        [HttpGet("Success")]
        public IActionResult Success()
        {
            return View("Success");
        }

        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
