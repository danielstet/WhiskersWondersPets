using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;
using WhiskersWondersPets.Data;
namespace WhiskersWondersPets.Models
{

    public class DbInitializer
    {
        public static async Task Initialize(AuthenticationContext context, UserManager<IdentityUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            context.Database.EnsureCreated();

            // Seed Roles
            if (!await roleManager.RoleExistsAsync("Admin"))
            {
                var role = new IdentityRole("Admin");
                await roleManager.CreateAsync(role);
            }

            if (!await roleManager.RoleExistsAsync("User"))
            {
                var role = new IdentityRole("User");
                await roleManager.CreateAsync(role);
            }

            // Seed Users
            if (userManager.Users.Count() == 0)
            {
                var adminUser = new IdentityUser { UserName = "admin" };
                await userManager.CreateAsync(adminUser, "Admin123!");
                await userManager.AddToRoleAsync(adminUser, "Admin");

                var regularUser = new IdentityUser { UserName = "user"};
                await userManager.CreateAsync(regularUser, "User123!");
                await userManager.AddToRoleAsync(regularUser, "User");
            }
        }
    }

}
