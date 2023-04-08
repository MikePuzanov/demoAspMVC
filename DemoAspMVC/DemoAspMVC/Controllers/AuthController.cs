using DemoAspMVC.Models;
using DemoAspMVC.Services;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DemoAspMVC.Controllers;

public class AuthController : Controller
{
    private readonly IAccountService _accountService;
    public AuthController(IAccountService accountService)
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
        var response = await _accountService.LoginUserAsync<ResponseDTO>(model);
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