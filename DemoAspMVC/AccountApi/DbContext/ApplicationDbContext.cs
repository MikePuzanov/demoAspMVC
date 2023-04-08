using AccountApi.Models;

namespace AccountApi.DbContext;

using Microsoft.EntityFrameworkCore;

public sealed class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    public DbSet<User> Users { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<User>().HasData(new User()
        {
            Id = 1,
            FirstName = "Иван",
            LastName = "Иванов",
            Email = "ivan@mail.ru",
            Password = "admin",
            Roles = new List<Role> { Role.Admin }
        });
        modelBuilder.Entity<User>().HasData(new User()
        {
            Id = 2,
            FirstName = "Петя",
            LastName = "Петров",
            Email = "petrov@mail.ru",
            Password = "user",
            Roles = new List<Role> { Role.User }
        });
    }
}