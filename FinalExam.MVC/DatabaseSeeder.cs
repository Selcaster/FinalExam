using FinalExam.DAL.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace FinalExam.MVC
{
    public static class DatabaseSeeder
    {
        public static async Task SeedData(IServiceProvider provider)
        {
            var userManager = provider.GetRequiredService<UserManager<IdentityUser>>();
            var roleManager = provider.GetRequiredService<RoleManager<IdentityRole>>();
            var db = provider.GetRequiredService<AppDbContext>();

            db.Database.Migrate();

            string[] roles = { "Admin", "User" };
            foreach (var role in roles)
            {
                if (!await roleManager.RoleExistsAsync(role))
                {
                    await roleManager.CreateAsync(new IdentityRole(role));
                }
            }

            string email = "admin@gmail.com";
            string userName = "admin";
            string password = "Admin123!";
            if (await userManager.FindByEmailAsync(email) is null)
            {
                IdentityUser user = new IdentityUser
                {
                    Email = email,
                    UserName = userName,
                    EmailConfirmed = true,
                };
                IdentityResult result = await userManager.CreateAsync(user, password);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(user, "Admin");
                }
            }
        }
    }
}
