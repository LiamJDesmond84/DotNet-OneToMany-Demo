﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DotNet_OneToMany_Demo.Models;

namespace DotNet_OneToMany_Demo.Controllers;

public class HomeController : Controller
{

    private static AppDbContext _context;

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

        ViewBag.Atlantic = _context.Teams.Where(x => x.CurrLeague.Name.Contains("Atlantic")).ToList();
        ViewBag.Penguins = _context.Players.Where(x => x.CurrentTeam.Location.Contains("Boston")).ToList();
        ViewBag.International = _context.Players.Where(x => x.CurrentTeam.CurrLeague.Name.Contains("Collegiate")).ToList();
        ViewBag.Lopez = _context.Players.Where(x => x.CurrentTeam.CurrLeague.Name.Contains("Amateur Football")).Where(x => x.LastName.Contains("Lopez")).ToList();
        ViewBag.AllFootball = _context.Players.Where(x => x.CurrentTeam.CurrLeague.Sport.Contains("Football")).ToList();

        ViewBag.TeamSophia = _context.Teams.Where(x => x.CurrentPlayers.Any(x => x.FirstName.Contains("Sophia"))).ToList();
        ViewBag.LeagueSophia = _context.Leagues.Where(x => x.Teams.Any((x => x.CurrentPlayers.Any(x => x.FirstName.Contains("Sophia"))))).ToList();

        ViewBag.LopezNotRough = _context.Players.Where(x => x.LastName.Contains("Lopez")).Where(x => !x.CurrentTeam.TeamName.Contains("RoughRiders")).ToList();



        return View();
    }

    [HttpGet("level_3")]
    public IActionResult Level3()
    {


        ViewBag.SamEvansNumber = _context.Teams.Where(x => x.AllPlayers.Any(y => y.PlayerId.Equals(1))).ToList();
        ViewBag.SamEvans = _context.Teams.Where(x => x.AllPlayers.Any(y => y.PlayerOnTeam.LastName.Equals("Evans"))).ToList();

        return View();
    }

}

