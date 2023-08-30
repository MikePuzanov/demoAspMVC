using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AuthApi.Model;
using Demo.Utils;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace AuthApi.Controllers;

[Route("api/account")]
public class AuthController : ControllerBase
{
    private readonly UserManager<IdentityUser> _userManager;
    private readonly RoleManager<IdentityRole> _roleManager;
    private readonly IOptions<AuthOptions> _options;

    public AuthController(RoleManager<IdentityRole> roleManager, UserManager<IdentityUser> userManager, IOptions<AuthOptions> options)
    {
        _roleManager = roleManager;
        _userManager = userManager;
        _options = options;
    }

    [HttpPost]
    [Route("login")]
    public async Task<IActionResult> Login([FromBody] LoginModel model)
    {
        var user = await _userManager.FindByNameAsync(model.Username);
        if (user != null && await _userManager.CheckPasswordAsync(user, model.Password))
        {
            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var securityKey = _options.Value.GetSymmetricSecuriryKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            
            var token = new JwtSecurityToken(
                _options.Value.Issuer,
                _options.Value.Audience,
                authClaims,
                expires: DateTime.Now.AddSeconds(Int32.Parse(_options.Value.TokenLifeTime)),
                signingCredentials: credentials);

            IdentityModelEventSource.ShowPII = true;

            return Ok(token);
        }

        return Unauthorized();
    }

    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegisterModel model)
    {
        var userExists = await _userManager.FindByNameAsync(model.Username);
        if (userExists != null)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response{ Status = "Error", Message = "User already exists!" });
        }

        IdentityUser user = new()
        {
            Email = model.Mail,
            SecurityStamp = Guid.NewGuid().ToString(),
            UserName = model.Username
        };
        var result = await _userManager.CreateAsync(user, model.Password);
        if (!result.Succeeded)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new Response{ Status = "Error", Message = "User creation failed! Please check user details and try again." });
        }

        return Ok(new Response{ Status = "Success", Message = "User created successfully!" });
    }
}