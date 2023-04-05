using Microsoft.EntityFrameworkCore;
using ProductApi.Models;

namespace ProductApi.DbContext;

public class SeedData
{
    public static void SeedDatabase(ApplicationDbContext context)
    {
        context.Database.Migrate();

        if (context.Products.Count() == 0)
        {
            context.AddRange(
    new Product {
                    Id = 1,
                    Name = "Молоток",
                    Price = 8,
                    Description = "Строительный инструмент",
                    ImageUrl = "",
                    CategoryName = "Инструмент" },
                new Product {
                    Id = 2,
                    Name = "Отвертка",
                    Price = 5,
                    Description = "Строительный инструмент",
                    ImageUrl = "",
                    CategoryName = "Инструмент" },
                new Product {
                    Id = 3,
                    Name = "Посуда",
                    Price = 14,
                    Description = "Кухонные приборы",
                    ImageUrl = "",
                    CategoryName = "Кухня" },
                new Product {
                    Id = 4,
                    Name = "Яблоко",
                    Price = 7,
                    Description = "Еда",
                    ImageUrl = "",
                    CategoryName = "Фрукты" },
                new Product {
                    Id = 5,
                    Name = "Огурец",
                    Price = 4,
                    Description = "Еда",
                    ImageUrl = "",
                    CategoryName = "Овощ" 
                });
        }

        context.SaveChangesAsync();
    }
}