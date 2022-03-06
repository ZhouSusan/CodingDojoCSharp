using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Dojodachi.Models;
using Microsoft.AspNetCore.Http;
using System.Text.Json;

namespace Dojodachi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            if (HttpContext.Session.GetInt32("Happiness") == null) 
            {
                HttpContext.Session.SetInt32("Happiness", 20);
            }
            if (HttpContext.Session.GetInt32("Fullness") == null) 
            {
                HttpContext.Session.SetInt32("Fullness", 20);
            }
            if (HttpContext.Session.GetInt32("Energy") == null) 
            {
                HttpContext.Session.SetInt32("Energy", 50);
            }
            if (HttpContext.Session.GetInt32("Meals") == null) 
            {
                HttpContext.Session.SetInt32("Meals", 3);
            }
            if (HttpContext.Session.GetInt32("Message") == null) 
            {
                HttpContext.Session.SetString("Message", "Hello, I am a your dojodachi pet");
            }


            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? fullness = HttpContext.Session.GetInt32("Fullness");
            int? meals = HttpContext.Session.GetInt32("Meals");

            ViewBag.Happiness = happiness;
            ViewBag.Meals = meals;
            ViewBag.Fullness = fullness;
            ViewBag.Energy = energy;
            ViewBag.Message = HttpContext.Session.GetString("Message");

            return View();
        }

        [HttpGet("feed")]
        public string FeedDachi() {
            if (HttpContext.Session.GetInt32("Meals") == 0)
            {
                return JsonSerializer.Serialize(new {message = "You can't feed our DojoDachi, if you do not have anything meals."});
            }
            else 
            {
                int? mealsCount = HttpContext.Session.GetInt32("Meals");
                mealsCount -= 1;
                HttpContext.Session.SetInt32("Meals", (int) mealsCount);
                Random rand = new Random();
                int? fullness = HttpContext.Session.GetInt32("Fullness");
                int randomFullness = rand.Next(0, 4);
                if (randomFullness == 0)
                {
                    return JsonSerializer.Serialize(new {message = "Your Dojodachi did not eat the meal."});
                }
                int fullnessAmt = rand.Next(5, 11);
                fullness += fullnessAmt;
                HttpContext.Session.SetInt32("Fullness", (int) fullness);
                return JsonSerializer.Serialize(new {message = $"You Dojodachi ate, and its fullness increased by {fullnessAmt}.", amount= fullness});
            }
        }

        [HttpGet("play")]
        public string PlayDachi() {
            int ? energy = HttpContext.Session.GetInt32("Energy");
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            Random rand = new Random();
            if (energy < 5)
            {
                return JsonSerializer.Serialize(new {message = "You do not have any energy", happiness = happiness, energy=energy});
            }
            else 
            {
                energy -= 5;
                HttpContext.Session.SetInt32("Energy", (int) energy);
                int energyRandom = rand.Next(0, 4);
                if (energyRandom == 0)
                {
                    return JsonSerializer.Serialize(new {message = "Your Dojodachi does not want to play", happiness = happiness, energy=energy});
                }
                else
                {
                    int happinesRandNum = rand.Next(5, 11);
                    happiness += happinesRandNum;
                    HttpContext.Session.SetInt32("Happiness", (int) happiness);
                    return JsonSerializer.Serialize(new {message = $"Your Dojodachi's happiness increased by {happinesRandNum}", happiness = happiness, energy=energy});
                }
            }
        }

        [HttpGet("work")]
        public string WorkDachi() {
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? meals = HttpContext.Session.GetInt32("Meals");
            if (energy < 5)
            {
                return JsonSerializer.Serialize(new {message = $"Your are too tired to work.", energy=energy, meals=meals});
            }
            energy -= 5;
            HttpContext.Session.SetInt32("Energy", (int) energy);
            Random rand = new Random();
            int mealsEarned =  rand.Next(1, 4);
            meals +=  mealsEarned;
            HttpContext.Session.SetInt32("Meals", (int) meals);
            return JsonSerializer.Serialize(new {message = $"Your earned {mealsEarned} meals.", energy=energy, meals=meals});
        }

        [HttpGet("sleep")]
        public string SleepDachi() 
        {
            int? happiness = HttpContext.Session.GetInt32("Happiness");
            int? energy = HttpContext.Session.GetInt32("Energy");
            int? fullness = HttpContext.Session.GetInt32("Fullness");

            energy += 15;
            fullness -= 5;
            happiness -= 5;

            HttpContext.Session.SetInt32("Fullness", (int) fullness);
            HttpContext.Session.SetInt32("Happiness", (int) happiness);
            HttpContext.Session.SetInt32("Energy", (int)energy);
            return JsonSerializer.Serialize(new {message = $"Your Dojodachi pet's has now a {fullness} fullness and {energy} energy.", energy=energy, fullness=fullness, happiness=happiness});

        }

        [HttpGet("restart")]
        public IActionResult Restart() {
            HttpContext.Session.Clear();
            return RedirectToAction("Index");
        }
    }
}
