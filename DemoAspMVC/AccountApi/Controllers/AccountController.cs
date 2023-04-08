using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AccountApi.DbContext;
using AccountApi.Middleware;
using AccountApi.Models;
using AccountApi.Services;
using AutoMapper;
using Demo.Utils;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AccountApi.Controllers;

[Route("api/account")]
public class AccountController : ControllerBase
{
    private readonly ApplicationDbContext _context;
    private readonly IUserService _userService;
    private readonly IOptions<AuthOptions> _options;
    private readonly IMapper _mapper;

    public AccountController(ApplicationDbContext context, IUserService userService, IOptions<AuthOptions> options, IMapper mapper)
    {
        _context = context;
        _userService = userService;
        _options = options;
        _mapper = mapper;
    }
    
    [Route("login")]
    [HttpPost]
    public async Task<IActionResult> Login([FromBody]Login model)
    {
        var userDto = await _userService.AuthenticateUser(model.Email, model.Password);
        var user = _mapper.Map<User>(userDto);
        if (user != null)
        {
            var token = GenerateJwt.GenerateJwtToken(user, _options);

            return Ok(new
            {
                access_token = token
            });
        }

        return Unauthorized();
    }
    
    
}