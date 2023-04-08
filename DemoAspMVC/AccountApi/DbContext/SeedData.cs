using Microsoft.EntityFrameworkCore;
using AccountApi.Models;

namespace AccountApi.DbContext;

public static class SeedData
{
    public static void SeedDatabase(ApplicationDbContext context)
    {
        context.Database.Migrate();

        if (context.Users.Count() == 0)
        {
            context.AddRange(
                new User()
                {
                    Id = 1,
                    FirstName = "Иван",
                    LastName = "Иванов",
                    Email = "ivan@mail.ru",
                    Password = "admin",
                    Roles = new List<Role> { Role.Admin }
                },
                new User()
                {
                    Id = 2,
                    FirstName = "Петя",
                    LastName = "Петров",
                    Email = "petrov@mail.ru",
                    Password = "user",
                    Roles = new List<Role> { Role.User }
                }
            );
        }

        context.SaveChangesAsync();
    }
}