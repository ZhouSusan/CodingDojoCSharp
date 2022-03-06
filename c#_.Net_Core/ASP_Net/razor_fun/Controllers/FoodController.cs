using Microsoft.AspNetCore.Mvc;
namespace Portfolio    
{
    public class FoodController : Controller  
    {
        [HttpGet]       
        [Route("")]    
        public ViewResult Index()
        {
            return View("Index");
        }
    }
}

