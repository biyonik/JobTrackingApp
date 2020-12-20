using JobTrackingApp.Entities.Concrete;
using Microsoft.AspNetCore.Identity;
using Task = System.Threading.Tasks.Task;

namespace JobTrackingApp.WebUI
{
    public static class IdentityInitializer
    {
        public static async Task SeedData(UserManager<AppUser> userManager, RoleManager<AppRole> roleManager)
        {
            var adminRole = await roleManager.FindByNameAsync("Admin");
            if (adminRole == null)
            {
                await roleManager.CreateAsync(new AppRole()
                {
                    Name = "Admin"
                });
            }

            var memberRole = await roleManager.FindByNameAsync("Member");
            if (memberRole == null)
            {
                await roleManager.CreateAsync(new AppRole()
                {
                    Name = "Member"
                });
            }

            var adminUser = await userManager.FindByNameAsync("SuperAdmin");
            if (adminUser == null)
            {
                AppUser appUser = new AppUser()
                {
                    FirstName = "Super",
                    SurName = "Admin",
                    UserName = "SuperAdmin",
                    Email = "superadmin@jobtrackingapp.com"
                };
                IdentityResult identityResult =  await userManager.CreateAsync(appUser, "jobtracking12345678");
                await userManager.AddToRoleAsync(appUser, "Admin");
            }

        }
    }
}