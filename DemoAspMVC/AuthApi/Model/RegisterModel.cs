using System.ComponentModel.DataAnnotations;

namespace AuthApi.Model;

public class RegisterModel
{
    [Required]
    public string Mail { get; set; }
    [Required]
    public string Username { get; set; }
    [Required]
    public string Password { get; set; }
}