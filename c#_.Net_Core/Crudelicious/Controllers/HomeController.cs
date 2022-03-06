using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Crudelicious.Models;

namespace Crudelicious.Controllers
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
            List<Dish> AllDishes = db.Dishes.OrderByDescending(d=>d.CreatedAt).ToList();
            return View("Index", AllDishes);
        }
        private readonly ILogger<HomeController> _logger;

        [HttpGet("new")]
        public IActionResult New()
        {
            return View("New");
        }

        [HttpPost("create")]
        public IActionResult Create(Dish newDish) 
        {
            if (ModelState.IsValid)
            {
                db.Add(newDish);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View("New");
        }

        [HttpGet("{DishId}")]
        public IActionResult ViewDish(int DishID)
        {
            Dish toView = db.Dishes.FirstOrDefault(d=>d.DishId==DishID);
            return View("ViewDish", toView);
        }

        [HttpGet("delete/{DishId}")]
        public IActionResult Delete(int DishID)
        {
            Dish removeDish = db.Dishes.FirstOrDefault(d=>d.DishId==DishID);
            db.Dishes.Remove(removeDish);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        [HttpGet("edit/{DishId}")]
        public IActionResult Edit(int DishID)
        {
            Dish editDish = db.Dishes.FirstOrDefault(d=>d.DishId==DishID);
            return View("Edit", editDish);
        }

        [HttpPost("update/{selectId}")]
        public IActionResult Update(Dish formDish, int selectId)
        {
            if (ModelState.IsValid == false)
            {
                formDish.DishId = selectId;
                return View("Edit", formDish);
            }
            Dish updateDish = db.Dishes.FirstOrDefault(d=>d.DishId==selectId);
            
            updateDish.Name = formDish.Name;
            updateDish.Chef = formDish.Chef;
            updateDish.Tastiness = formDish.Tastiness;
            updateDish.Calories = formDish.Calories;
            updateDish.Description = formDish.Description;
            updateDish.UpdatedAt = DateTime.Now;
            db.SaveChanges();

            return RedirectToAction("ViewDish", new {DishId = selectId});
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
