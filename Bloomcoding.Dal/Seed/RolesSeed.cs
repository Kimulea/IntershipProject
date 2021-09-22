using Bloomcoding.Dal.Constants;
using Bloomcoding.Domain.Auth;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Bloomcoding.Dal.Seed
{
    public class RolesSeed
    {
        public static async Task Seed(RoleManager<Role> roleManager)
        {
            await roleManager.CreateAsync(new Role() { Name = UserRoles.Admin });
            await roleManager.CreateAsync(new Role() { Name = UserRoles.Student });
            await roleManager.CreateAsync(new Role() { Name = UserRoles.Teacher });
        }
    }
}
