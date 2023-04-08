using ProductApi.Models;

namespace ProductApi.DbContext;

using Microsoft.EntityFrameworkCore;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        
    }

    public DbSet<Product> Products { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 1,
            Name = "Молоток",
            Price = 8,
            Description = "Строительный инструмент",
            ImageUrl = "",
            CategoryName = "Инструмент"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 2,
            Name = "Отвертка",
            Price = 5,
            Description = "Строительный инструмент",
            ImageUrl = "",
            CategoryName = "Инструмент"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 3,
            Name = "Посуда",
            Price = 14,
            Description = "Кухонные приборы",
            ImageUrl = "",
            CategoryName = "Кухня"
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 4,
            Name = "Яблоко",
            Price = 7,
            Description = "Еда",
            ImageUrl = "",
            CategoryName = "Фрукты"
        });
        modelBuilder.Entity<Product>().HasData(new Product {
            Id = 5,
            Name = "Огурец",
            Price = 4,
            Description = "Еда",
            ImageUrl = "",
            CategoryName = "Овощ" 
        });
    }
}