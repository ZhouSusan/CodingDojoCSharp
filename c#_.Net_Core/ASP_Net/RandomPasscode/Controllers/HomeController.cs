using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RandomPasscode.Models;
using Microsoft.AspNetCore.Http;



namespace RandomPasscode.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public void CreateRandomPassword(int length=14) {

            string validChars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random rand = new Random();
            char[] randomChars = new char[length];
            
            for (int i = 0; i < length; i++) {
                randomChars[i] = validChars[rand.Next(validChars.Length)];
            }
            TempData["newPasscode"] = new string(randomChars);
        }

        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Count") == null) {
                HttpContext.Session.SetInt32("Count", 1);
            }
            //to retrieve an int from session, we use GetInt32
            int? count = HttpContext.Session.GetInt32("Count");

            ViewBag.Count = count;
            ViewBag.Passcode = TempData["newPasscode"];

            CreateRandomPassword();
            return View();
        }

        [HttpGet("new")]
        public IActionResult New()
        {
            int? count = HttpContext.Session.GetInt32("Count");
            count++;
            HttpContext.Session.SetInt32("Count", (int)count);
            return RedirectToAction("Index");
        }
    }
}
