using System.ComponentModel.DataAnnotations;

namespace ProductApi.Models;

public class Product
{
    [Key]
    public long Id { get; set; }
    [Required]
    public String Name { get; set; }
    [Required]
    public double Price { get; set; }
    [Required]
    public String Description { get; set; }
    [Required]
    public String CategoryName { get; set; }
    [Required]
    public String ImageUrl { get; set; }
}