using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using TheWall.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace TheWall.Controllers
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
                return RedirectToAction("Dashboard");
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
                return RedirectToAction("Dashboard");
            }
            return View("Index");
        }

        [HttpGet("/Dashboard")]
        public IActionResult Dashboard()
        {
                if (HttpContext.Session.GetInt32("UserId") == null)
                {
                    return RedirectToAction("Index");
                }
                int? uuid = HttpContext.Session.GetInt32("UserId");
                User currentUser = db.Users
                    .FirstOrDefault(u=> u.UserId == uuid);
                ViewBag.CurrentUser = currentUser;

                List<Message> AllMessages = db.Messages
                    .Include(u=>u.User)
                        .Include(c => c.Comments)
                            .ThenInclude(u => u.ComCreator)
                            .OrderByDescending(m=>m.CreatedAt)
                            .ToList();
                
                ViewBag.AllMessages = AllMessages;

                return View("Dashboard");
        }

        [HttpPost("CreateMessage")]
        public IActionResult CreateMessage(Message newMsg)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                int? uuid = HttpContext.Session.GetInt32("UserId");
                db.Add(newMsg);
                db.SaveChanges();
                return Redirect("Dashboard");
            }
            return View("Index");
        }

        [HttpPost("CreateComment/{MessageId}")]
        public IActionResult CreateComment(Comment newComt, int MessageId)
        {
            if (HttpContext.Session.GetInt32("UserId") != null)
            {
                int? uuid = HttpContext.Session.GetInt32("UserId");
                newComt.UserId = (int)uuid;
                db.Add(newComt);
                db.SaveChanges();
                return Redirect("Dashboard");
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
