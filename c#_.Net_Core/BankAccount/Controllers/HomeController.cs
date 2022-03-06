using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BankAccount.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace BankAccount.Controllers
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
        public IActionResult Register(User newUser)
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
                newUser.Password = Hasher.HashPassword(newUser, newUser.Password);
                db.Add(newUser);
                db.SaveChanges();
                HttpContext.Session.SetInt32("UserId", newUser.UserId);
                return Redirect("/Account/" + newUser.UserId);
            }

            return View("Index");
        }

        [HttpPost("loginUser")]
        public IActionResult LoginUser(LogUser logUser)
        {
            if (ModelState.IsValid)
            {
                User userindb = db.Users.FirstOrDefault(u => u.Email == logUser.LoginEmail);
                if (userindb == null)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid login attempt");
                    return View("Index");
                }
                //check if password is correct
                PasswordHasher<LogUser> Hasher = new PasswordHasher<LogUser>();
                PasswordVerificationResult result = Hasher.VerifyHashedPassword(logUser, userindb.Password, logUser.LoginPassword); 
                //When the vertifcation runs, it will passed 1(successfully) or 0(password is incorrect)
                if (result == 0)
                {
                    ModelState.AddModelError("LoginEmail", "Invalid login attempt");
                    return View("Index");
                }

                HttpContext.Session.SetInt32("UserId", userindb.UserId);
                return Redirect("/Account/" + userindb.UserId);
            }
            return View("Index");
        }

        [HttpGet("/Account/{user_Id}")]
        public IActionResult Dashboard(int user_Id)
        {
                if (HttpContext.Session.GetInt32("UserId") == null)
                {
                    return RedirectToAction("Index");
                }

                if (HttpContext.Session.GetInt32("UserId") != user_Id)
                {
                    int ? UserId = HttpContext.Session.GetInt32("UserId");
                    return RedirectToAction("Index");
                }

                User currentUser = db.Users
                .Include(u => u.Transactions)
                .Where(u => u.UserId == user_Id)
                .SingleOrDefault();

                if (currentUser.Transactions != null)
                {
                    currentUser.Transactions = db.Transaction.
                    OrderByDescending(c=>c.CreatedAt)
                    .ToList();
                }
                ViewBag.CurrentUser = currentUser;
                return View("Dashboard");
        }

        [HttpPost("Transaction")]
        public IActionResult Transaction(decimal amount)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                User currentUser =  db.Users.FirstOrDefault(u => u.UserId == HttpContext.Session.GetInt32("UserId"));
                if (amount > 0)
                {
                    currentUser.Balance += amount;
                    //Create a new isntance of an object of transaction
                    Transaction newTrans = new Transaction {
                        Amount = amount,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        UserId = currentUser.UserId
                    };
                db.Add(newTrans);
                db.SaveChanges();
                return Redirect("/Account/" + currentUser.UserId);
                }
                else if (amount + currentUser.Balance < 0)
                {
                    ModelState.AddModelError("Amount", "Insufficient funds");
                    return Redirect("/Account/" + currentUser.UserId);
                }
                else 
                {
                    currentUser.Balance += amount;
                    Transaction newTransaction = new Transaction {
                        Amount = amount,
                        CreatedAt = DateTime.Now,
                        UpdatedAt = DateTime.Now,
                        UserId = currentUser.UserId
                    };
                    db.Add(newTransaction);
                    db.SaveChanges();
                    return Redirect("/Account/" + currentUser.UserId);
                }
            }

            return View("Index");
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
