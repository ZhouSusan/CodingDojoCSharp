using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SportsORM.Models;
using Microsoft.EntityFrameworkCore;


namespace SportsORM.Controllers
{
    public class HomeController : Controller
    {

        private static Context _context;

        public HomeController(Context DBContext)
        {
            _context = DBContext;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            ViewBag.BaseballLeagues = _context.Leagues
                .Where(l => l.Sport.Contains("Baseball"))
                .ToList();

            return View();
        }



        [HttpGet("level_1")]
        public IActionResult Level1()
        {
            ViewBag.BaseballLeagues = _context.Leagues
            .Where(l => l.Name.ToLower().Contains("women"))
            .ToList();

            ViewBag.HockeySports = _context.Leagues
            .Where(h => h.Sport.ToLower().Contains("hockey"))
            .ToList();

            ViewBag.NotFootball = _context.Leagues
            .Where(o => !o.Sport.ToLower().Contains("football"))
            .ToList();

            ViewBag.ConferenceLeagues = _context.Leagues
            .Where(c => c.Name.ToLower().Contains("conference"))
            .ToList();

            ViewBag.AtlanticLeagues = _context.Leagues
            .Where(a => a.Name.ToLower().Contains("atlantic"))
            .ToList();

            ViewBag.DallasTeam = _context.Teams
            .Where(d => d.Location.ToLower().Contains("dallas"))
            .ToList();

            ViewBag.RaptorsTeam = _context.Teams
            .Where(rap => rap.TeamName.ToLower().Contains("raptors"))
            .ToList();

            ViewBag.CityLocation = _context.Teams
            .Where(city=>city.Location.ToLower().Contains("city"))
            .ToList();

            ViewBag.TNames = _context.Teams
            .Where(t => t.TeamName.ToLower().StartsWith("t"))
            .ToList();

            ViewBag.Locations = _context.Teams
            .OrderBy(l => l.Location)
            .ToList(); 

            ViewBag.ReversedLocations = _context.Teams
            .OrderByDescending(l => l.TeamName)
            .ToList(); 

            ViewBag.Copper = _context.Players
            .Where(coop => coop.LastName.ToLower().Contains("cooper"))
            .ToList();

            ViewBag.Joshua = _context.Players
            .Where(josh => josh.FirstName.ToLower().Contains("joshua"))
            .ToList();

            ViewBag.CooperWithout = _context.Players
            .Where(coop => coop.LastName.ToLower().Contains("cooper") && !coop.FirstName.ToLower().Contains("joshua"))
            .ToList();

            ViewBag.AlexOrWyatt = _context.Players
            .Where(fname=>fname.FirstName.ToLower().Contains("alexander") || fname.FirstName.ToLower().Contains("wyatt"))
            .ToList();

            return View();
        }

        [HttpGet("level_2")]
        public IActionResult Level2()
        {
            // int LeagueId = _context.Leagues.Where(league => league.Name == "Atlantic Soccer Conference").First().LeagueId;
            ViewBag.AtlanticSoccerConf = _context.Teams.Include("CurrLeague").Where(teamleague => teamleague.CurrLeague.Name == "Atlantic Soccer Conference").ToList();

            ViewBag.BostonPegguins = _context.Players.Include("CurrentTeam").Where(playerteam => playerteam.CurrentTeam.Location == "Boston" && playerteam.CurrentTeam.TeamName == "Penguins").ToList();

            ViewBag.PlayersInICBC = _context.Teams.Include("CurrentPlayers").Include("CurrLeague").Where(ptl => ptl.CurrLeague.Name == "International Collegiate Baseball Conference").ToList();

            ViewBag.PlayersInAmatuerFootball = _context.Players.Include("CurrentTeam").Include("CurrentTeam.CurrLeague").Where(ptl => ptl.LastName == "Lopez" && ptl.CurrentTeam.CurrLeague.Name == "American Conference of Amateur Football").ToList();

            ViewBag.PlayersFootball = _context.Players.Include("CurrentTeam").Include("CurrentTeam.CurrLeague").Where(p=>p.CurrentTeam.CurrLeague.Sport == "Football").ToList();

            ViewBag.TeamPlayerSophia = _context.Teams.Include("CurrentPlayers").Where(pt => pt.CurrentPlayers.Where(x=>x.FirstName == "Sophia").Any()).ToList();

            ViewBag.LeaguePlayerSophia = _context.Leagues.Include("Teams").Include("Teams.CurrentPlayers").Where(lpt => lpt.Teams.Where(team => team.CurrentPlayers.Where(x=>x.FirstName == "Sophia").Any()).Any()).ToList();

            ViewBag.FloresNotInWR = _context.Players.Include("CurrentTeam").Where(p=>p.LastName == "Flores" && (p.CurrentTeam.Location != "Washington" && p.CurrentTeam.TeamName != "Roughriders")).ToList();
            return View();
        }

        [HttpGet("level_3")]
        public IActionResult Level3()
        {
            return View();
        }

    }
}