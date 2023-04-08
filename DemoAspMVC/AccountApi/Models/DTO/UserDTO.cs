using System.ComponentModel.DataAnnotations;

namespace AccountApi.Models.DTO;

public class UserDTO
{
    [Key]
    public long Id { get; set; }
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string Email { get; set; }
    [Required]
    public string Password { get; set; }
    public List<Role> Roles { get; set; }
}