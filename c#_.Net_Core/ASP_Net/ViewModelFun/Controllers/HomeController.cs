using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ViewModelFun.Models;

namespace ViewModelFun.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public List<User> GetUsers() 
        {
            List<User> Users = new List<User>() {
                new User(){FirstName = "Moose", LastName="Phillips"},
                new User() {FirstName = "Sarah"},
                new User() {FirstName = "Rene", LastName="Ricky"},
                new User(){FirstName="Barbarah"}
            };
            return Users;
        }

        [HttpGet]
        [Route("")]
        public IActionResult Index()
        {
            string msg = "Here is a Message!";
            return View("Index", msg);
        }

        [HttpGet]
        [Route("numbers")]
        public IActionResult NumbersList()
        {
            int[] numbers = {1, 2, 3, 10, 43, 5};
            return View("Numbers", numbers);
        }

        [HttpGet]
        [Route("users")]
        public IActionResult UsersList()
        {
            var names = GetUsers();
            return View("Users", names);
        }

        [HttpGet]
        [Route("user")]
        public IActionResult AUser()
        {
            Random rand = new Random();
            var users = GetUsers();
            var user = users[rand.Next(users.Count)];
            return View("User", user);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
