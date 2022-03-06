using System;
using Microsoft.AspNetCore.Mvc;
namespace HelloASP     //be sure to use your own project's namespace!
{
    public class HelloController : Controller   //remember inheritance??
    {
        //for each route this controller is to handle:
        // [Route("")]     //associated route string (exclude the leading /)
        [HttpGet("")]       //type of request
        public IActionResult Index() //ViewResult is a type of response that describes a render to review that is a
        //a repsonse that is porvided by the frameworks that includes all of the content for the broswers to render and load html
        //and other data we are passing
        //Hi There is the name of my action
        {
            //By deault, View will look for a file called HiThere.cshtml(file extension for razer-razer is our view engine) and 
            //Views/Hello(name of the controller)/ HiThere.cshtml 
            ViewBag.Example = "Hello World!";
            return View("Index");
            //A view method returns a view itself 
            //We can call View with no arugments, in the case the framwork will atttmept to find a file, the name of your action

        }

        [Route("hello")]     //associated route string (exclude the leading /)
        [HttpGet]       //type of request
        public IActionResult Hello()
        {
            //make a redirect to localhost:5000/
            Console.WriteLine("Hello There, redirecting...");
            return RedirectToAction("HelloUser", new{username="Susan", location="Seattle"});//takes a url path(issues is the url path can change, and we will manaully have to change it) or an action
        }
        //localhost/users/???" 
        [HttpGet("users/{username}/{location}")]
        public IActionResult HelloUser(string username, string location) {
            var response = new{user=username, place=location};
            if (location == "Seattle") 
            {
                return Json(response);
            }
            else if(location == "Chicago")
            {
                return View("Index");
            }
            return RedirectToAction("Index");
        }
    }
}

//Controller main responsilbilty handling requests and delivering back responses
//handling request- we need to consume a route-i.e local host:5000, we use a route attribute and empty string
//[Route("")]- will pair us with  and anything that comes after it with base url
//the request is the handling of the route, the response is a mthod
//[Route("")]- tie to our route
//[HttpGet]
//public string Index()  (provide a string reponse) {
    //return "Hello From Controllers";
//}

//localhost:5000/hello => [Route("hello")]
//[HttpGet] - default http attribute
//[HttpPost]
//publuc string Hello() {
    //return "Hi Again!"
//}
//-these handle repsonses

//HelloController is simply a class inherting from MVC COntroller class, and it recieves all the functionality it needs to perfom its central duties as a Controller
//to intercept requests, proveide server response to those requests

//ASP has the spcial bame for OCntroller method that devliers a server response: Action. 
//There are two parts that make up action- that is matched with a route and that delvers with a valid respinse 
//a string is a vlaid respnse, and will be served as text content to the client
//Get resquests to localhost:5000/ will be matched with our Index action, which in turn will delver back its text response


//Attributes are special type of classes that have the word Attribute, int he class name; howeven when we use them, we can omit the word Attribute

// [RouteAttribute]
// We can match specific url strings to our Controller actions by providing a 
// RouteAttribute above the method itself.  We provide this attribute a string for 
// the url we are looking to handle (leading slash not required).  
// For example, [Route("")] will match localhost:5000, or the root url.  
// [Route("users")] will match localhost:5000/users, 
// and [Route("users/more"] will match localhost:5000/users/more. 

// [HttpMethodAttribute]
//   If we are looking to handle a GET request [HttpGet].  
//   POST requests are handled by [HttpPost]

// [HttpMethodAttribute(Route)]
//  you can combine a RouteAttribute and a HttpMethodAttribute, 
//  by providing a route string to a HttpMethodAttribute.  
//  For example [HttpGet("")] will be matched with GET requests to localhost:5000

// Route Parameters
// If you need to support a variable in your url string,
//  you can use the RouteAttribute with route parameters.  
//  The syntax for this is quite simple: wrap the route parameter in curly braces, 
//  like so: [Route("users/{userName}"].  The name of the route parameter can then be used 
//  as an argument to the matching action in your Controller.  
// The argument type can be either string or int, depending on the expected url.