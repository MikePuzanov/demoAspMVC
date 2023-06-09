﻿using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoAspMVC.Models;
using Microsoft.AspNetCore.Authorization;

namespace DemoAspMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    
    public IActionResult Login()
    {
        return RedirectToAction(nameof(Index));
    }
    
    [Authorize]
    public IActionResult Logout()
    {
        return SignOut("Cookies", "iodc");
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}