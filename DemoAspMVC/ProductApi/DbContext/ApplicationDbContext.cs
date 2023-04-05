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
            Name = "",
            Price = 13,
            Description = "",
            ImageUrl = "",
            CategoryName = "",
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 2,
            Name = "",
            Price = 13,
            Description = "",
            ImageUrl = "",
            CategoryName = "",
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 3,
            Name = "",
            Price = 13,
            Description = "",
            ImageUrl = "",
            CategoryName = "",
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 4,
            Name = "",
            Price = 13,
            Description = "",
            ImageUrl = "",
            CategoryName = "",
        });
        modelBuilder.Entity<Product>().HasData(new Product
        {
            Id = 5,
            Name = "",
            Price = 13,
            Description = "",
            ImageUrl = "",
            CategoryName = "",
        });
    }
}