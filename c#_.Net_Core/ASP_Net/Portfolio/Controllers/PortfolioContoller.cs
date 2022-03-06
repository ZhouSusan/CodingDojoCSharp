using Microsoft.AspNetCore.Mvc;
namespace Portfolio    
{
    public class PortfolioController : Controller  
    {

        [HttpGet]       
        [Route("")]    
        public ViewResult Index()
        {
            ViewBag.Example = "Hello World!";
            return View("Index");
        }

        [HttpGet]       
        [Route("project")]    
        public ViewResult Project()
        {
            return View("project");
        }

        [HttpGet("contact")]         
        public ViewResult Contact()
        {
            return View("Contact");
        }
    }
}

