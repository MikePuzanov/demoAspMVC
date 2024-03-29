using DemoAspMVC.Models;
using DemoAspMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace DemoAspMVC.Controllers;

public class AuthController : Controller
{
    private readonly IAuthService _authService;
    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }
    
    public async Task<IActionResult> Login()
    {
        return View();
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

    public async Task<IActionResult> Logout([FromBody] Login model)
    {
        return View();
    }
}