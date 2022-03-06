using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ChefDishes.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace ChefDishes.Controllers
{
    public class HomeController : Controller
    {
    private MyContext db;

        // here we can "inject" our context service into the constructor
        public HomeController(MyContext context)
        {
            db = context;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            List <Chef> AllChefs = db.Chefs.Include("Dishes").ToList();
            ViewBag.AllChefs = AllChefs;
            return View("Index");
        }

        [HttpPost("AddChef")]
        public IActionResult AddChef(Chef newChef) 
        {   
            if(ModelState.IsValid)
            {
                db.Add(newChef);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View("New");
        }

        [HttpGet("Home/Dishes")]
        public IActionResult DisplayDishes()
        {
            ViewBag.AllDishes = db.Dishes.Include(dish=>dish.Creator).ToList();
            return View("AllDishes");
        }

        [HttpGet("New")]
        public IActionResult NewChef()
        {
            return View("New");
        }


        [HttpPost("AddDish")]
        public IActionResult AddDish(Dish newDish)
        {
            if(ModelState.IsValid)
            {
                Chef creator = db.Chefs.FirstOrDefault(c => c.ChefId == newDish.ChefId);
                newDish.Creator = creator;
                newDish.ChefName = newDish.Creator.FirstName + " " + newDish.Creator.LastName;
                db.Add(newDish);
                db.SaveChanges();
                return RedirectToAction("DisplayDishes");
            }
            ViewBag.AllChefs = db.Chefs.ToList();
            return View("NewDish");
        }

        [HttpGet("Home/dishes/new")]
        public IActionResult NewDish()
        {
            ViewBag.AllChefs = db.Chefs.ToList();
            return View("NewDish");
        }

    }
}
