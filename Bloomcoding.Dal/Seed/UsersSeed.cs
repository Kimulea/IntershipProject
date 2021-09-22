using Bloomcoding.Dal.Constants;
using Bloomcoding.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Bloomcoding.Dal.Seed
{
    public class UsersSeed
    {
        public static async Task Seed(UserManager<User> userManager, RoleManager<Role> roleManager)
        {
            if (!userManager.Users.Any())
            {
                var user1 = new User()
                {
                    UserName = "admin",
                    Email = "admin@bloomcoding.com",
                };
                await userManager.CreateAsync(user1, "Admin123#");

                if (await roleManager.RoleExistsAsync(UserRoles.Admin))
                {
                    await userManager.AddToRoleAsync(user1, UserRoles.Admin);
                }

                var user2 = new User()
                {
                    UserName = "student",
                    Email = "student@bloomcoding.com",
                };
                await userManager.CreateAsync(user2, "Student123#");

                if (await roleManager.RoleExistsAsync(UserRoles.Student))
                {
                    await userManager.AddToRoleAsync(user2, UserRoles.Student);
                }

                var user3 = new User()
                {
                    UserName = "Teacher",
                    Email = "teacher@bloomcoding.com",
                };
                await userManager.CreateAsync(user3, "Teacher123#");

                if (await roleManager.RoleExistsAsync(UserRoles.Teacher))
                {
                    await userManager.AddToRoleAsync(user3, UserRoles.Teacher);
                }
            }
        }
    }
}
