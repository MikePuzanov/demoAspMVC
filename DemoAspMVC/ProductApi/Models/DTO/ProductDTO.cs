namespace ProductApi.Models.DTO;

public class ProductDTO
{
    public long Id { get; set; }
    public String Name { get; set; }
    public double Price { get; set; }
    public String Description { get; set; }
    public String CategoryName { get; set; }
    public String ImageUrl { get; set; }
}