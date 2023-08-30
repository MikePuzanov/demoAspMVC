using System.ComponentModel.DataAnnotations;

namespace AuthApi.Model;

public class LoginModel
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}