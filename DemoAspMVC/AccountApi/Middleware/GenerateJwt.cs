using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using AccountApi.Models;
using Demo.Utils;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Logging;
using Microsoft.IdentityModel.Tokens;

namespace AccountApi.Middleware;

public static class GenerateJwt
{
    public static string GenerateJwtToken(User user, IOptions<AuthOptions> options)
    {
        var authParams = options.Value;

        var securityKey = authParams.GetSymmetricSecuriryKey();
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>()
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email),
            new Claim(JwtRegisteredClaimNames.Name, user.FirstName),
            new Claim(JwtRegisteredClaimNames.FamilyName, user.LastName),
            new Claim(JwtRegisteredClaimNames.Sub, user.Id.ToString())
        };

        foreach (var role in user.Roles)
        {
            claims.Add(new Claim("role", role.ToString()));
        }

        var token = new JwtSecurityToken(authParams.Issuer,
            authParams.Audience,
            claims,
            expires: DateTime.Now.AddSeconds(Int32.Parse(authParams.TokenLifeTime)),
            signingCredentials: credentials);

        IdentityModelEventSource.ShowPII = true;
        
        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}