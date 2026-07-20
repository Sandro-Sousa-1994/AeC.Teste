using AeC.Teste.Web.Models;
using Microsoft.AspNetCore.Identity;

namespace AeC.Teste.Web.Data.Seed
{
    public class DbInitializer
    {
        public static async Task SeedAsync(AppDbContext context)
        {
            if (context.Users.Any())
                return;

            var passwordHasher = new PasswordHasher<User>();

            var user = new User
            {
                Name = "Administrador",
                Username = "admin"
            };

            user.PasswordHash = passwordHasher.HashPassword(user, "123456");

            context.Users.Add(user);

            await context.SaveChangesAsync();
        }
    }
}
