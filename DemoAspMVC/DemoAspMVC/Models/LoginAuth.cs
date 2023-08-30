using System.ComponentModel.DataAnnotations;

namespace DemoAspMVC.Models;

public class LoginAuth
{
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}