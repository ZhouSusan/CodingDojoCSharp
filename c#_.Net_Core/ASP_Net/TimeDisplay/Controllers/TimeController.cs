using Microsoft.AspNetCore.Mvc;
namespace TimeDisplay 
{
    public class TimeController : Controller  
    {

        [HttpGet]       
        [Route("")]    
        public ViewResult Index()
        {
            return View("Index");
        }

    }
}