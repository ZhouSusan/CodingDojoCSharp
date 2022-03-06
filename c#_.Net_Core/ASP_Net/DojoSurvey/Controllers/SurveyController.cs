using System;
using Microsoft.AspNetCore.Mvc;
using DojoSurvey.Models;
namespace DojoSurvey.Controllers
{
    public class SurveyController : Controller  
    {

        [HttpGet]       
        [Route("")]    
        public IActionResult Index()
        {
            return View();
        }

        
        [HttpPost("/survey")]
        public IActionResult Submission(Survey yourSurvey)
        {
            return View("Result", yourSurvey);
        }
    }
}