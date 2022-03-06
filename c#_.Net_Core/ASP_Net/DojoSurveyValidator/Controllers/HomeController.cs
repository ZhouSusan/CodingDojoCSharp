using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using DojoSurveyValidator.Models;

namespace DojoSurveyValidator.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        static Survey newSurvey;

        [HttpGet]       
        [Route("")]    
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost("submit")]
        public IActionResult Submit(Survey yourSurvey)
        {
            newSurvey = yourSurvey;
            if (ModelState.IsValid)
            {
                return RedirectToAction("Success");
            }
            else 
            {
                return View("Index");
            }
        }

        [HttpGet("success")]
        public ViewResult Success() 
        {
            return View("Result", newSurvey);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
