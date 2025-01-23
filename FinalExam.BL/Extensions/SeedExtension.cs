using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using FinalExam.Core.Entities;
using Microsoft.Extensions.DependencyInjection;
using Google.Apis.Admin.Directory.directory_v1.Data;

namespace FinalExam.BL.Extensions;

    public static class SeedExtension
    {
        public static void UseCustomUserData(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var _roleManager = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
                var _userManager = scope.ServiceProvider.GetRequiredService <UserManager<Core.Entities.User>>();

                CreateRoles(_roleManager).Wait();
                CreateAdmin(_userManager).Wait();
            }
        }

        private async static Task CreateRoles(RoleManager<IdentityRole> _roleManager)
        {
            int res = await _roleManager.Roles.CountAsync();
            if (res == 0)
            {
                foreach (Core.Entities.Roles role in Enum.GetValues(typeof(Core.Entities.Roles)))
                {
                    await _roleManager.CreateAsync(new IdentityRole(role.ToString()));
                }
            }
        }

        private async static Task CreateAdmin(UserManager<Core.Entities.User> _userManager)
        {
            if (!await _userManager.Users.AnyAsync(x => x.UserName == "admin"))
            {
                Core.Entities.User admin = new Core.Entities.User
                {
                    Fullname = "admin",
                    UserName = "admin",
                    Email = "admin@gmail.com",
                };
                admin.EmailConfirmed = true;

                await _userManager.CreateAsync(admin, "123");
                await _userManager.AddToRoleAsync(admin, "Admin");
            }
        }
    }
