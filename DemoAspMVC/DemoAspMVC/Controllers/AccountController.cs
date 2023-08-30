using DemoAspMVC.Models;
using DemoAspMVC.Services;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoAspMVC.Controllers;

public class AccountController : Controller
{
    private readonly IAccountService _accountService;
    public AccountController(IAccountService accountService)
    {
        _accountService = accountService;
    }
    
    public async Task<IActionResult> Login()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Login(Login model)
    {
        var accessToken = await HttpContext.GetTokenAsync("access_token");
        var response = await _accountService.LoginUserAsync<ResponseDTO>(model, accessToken);
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