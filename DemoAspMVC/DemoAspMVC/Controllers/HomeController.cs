using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using DemoAspMVC.Models;
using DemoAspMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;

namespace DemoAspMVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly IAuthService _authService;

    public HomeController(ILogger<HomeController> logger, IAuthService authService)
    {
        _logger = logger;
        _authService = authService;
    }

    public IActionResult Index()
    {
        return View();
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
    
    [Authorize]
    public IActionResult Login()
    {
        return RedirectToAction(nameof(Index));
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(LoginAuth model)
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        var response = await _authService.LoginUserAsync<ResponseDTO>(model, accessToken);
        accessToken = await HttpContext.GetTokenAsync("access_token");
        if (response is { IsSuccess: true })
        {
            return RedirectToAction("Index", "Home");
        }

        return View("Login");
    }

    public IActionResult Logout([FromBody] Login model)
    {
        return SignOut("Cookies", "oidc");
    }
}