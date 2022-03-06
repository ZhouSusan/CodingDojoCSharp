using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using LoginReg.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Http;

namespace LoginReg.Controllers
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
            return View();
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
                return RedirectToAction("Success");
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
                return RedirectToAction("Success");
            }
            return View("Index");
        }


        [HttpGet("success")]
        public IActionResult Success()
        {
                if (HttpContext.Session.GetInt32("UserId") == null)
                {
                    return RedirectToAction("Index");
                }
                return View("Success");
        }

        [HttpPost("logout")]
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
