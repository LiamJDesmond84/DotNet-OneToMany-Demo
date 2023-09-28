using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotNet_OneToMany_Demo.Models;

namespace DotNet_OneToMany_Demo.Controllers;

public class HomeController : Controller
{

    private AppDbContext _context;

    public HomeController(AppDbContext context)
    {
        _context = context;
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
        ViewBag.Leagues = _context.Leagues.Where(x => x.Name.Contains("Women")).ToList();

        var test = _context.Leagues.Where(x => x.Name.Contains("Women")).ToList();

        Debug.WriteLine("******************TEST TEST TEST TEST TEST TEST TEST******************" + test.ToList());

        foreach(var x in test)
        {
            Debug.WriteLine("*****************" + x);
        }
        ViewBag.Hockey = _context.Leagues.Where(x => x.Sport.Contains("Hockey")).ToList();
        ViewBag.NotFootball = _context.Leagues.Where(x => !x.Sport.Contains("Football")).ToList();
        ViewBag.Conferences = _context.Leagues.Where(x => x.Name.Contains("Conference")).ToList();
        ViewBag.Atlantic = _context.Leagues.Where(x => x.Name.Contains("Atlantic")).ToList();

        ViewBag.Dallas = _context.Teams.Where(x => x.Location.Contains("Dallas")).ToList();
        ViewBag.Raptors = _context.Teams.Where(x => x.TeamName.Contains("Raptors")).ToList();
        ViewBag.City = _context.Teams.Where(x => x.Location.Contains("City")).ToList();
        ViewBag.TStart = _context.Teams.Where(x => x.TeamName.StartsWith("T")).ToList();
        ViewBag.AlphaLocation = _context.Teams.OrderBy(x => x.Location).ToList();
        ViewBag.ReverseAlpha = _context.Teams.OrderByDescending(x => x.TeamName).ToList();
        return View();
    }

    [HttpGet("level_2")]
    public IActionResult Level2()
    {
        return View();
    }

    [HttpGet("level_3")]
    public IActionResult Level3()
    {
        return View();
    }

}

