using Microsoft.AspNetCore.Identity;
using urfit_presence.Data;

public static class ApplicationDbInitializer
{
    public static async Task SeedUsersAndRolesAsync(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        
        string[] roles = new string[] { "Owner", "Administrator", "User" };

        foreach (string role in roles)
        {
            var r = await roleManager.FindByNameAsync(role);
            if (r is null)
            {
                await roleManager.CreateAsync(new IdentityRole(role));
            }
        }

        var vavdb = await userManager.FindByEmailAsync("vincent@urfit.nu");
        var ljvdbb = await userManager.FindByEmailAsync("leydi@urfit.nu");
        if (vavdb is null)
        {
            vavdb = new ApplicationUser
                    {
                        UserName = "vavdb",
                        Email = "vincent@urfit.nu"
                    };

            var result = await userManager.CreateAsync(vavdb, "Dummy123!");
        }
        if (ljvdbb is null)
        {
            ljvdbb = new ApplicationUser
                     {
                         UserName = "ljvdbb",
                         Email = "leydi@urfit.nu"
                     };

            var result = await userManager.CreateAsync(ljvdbb, "Dummy123!");
        }
        await userManager.AddToRoleAsync(vavdb, "Administrator");
        await userManager.AddToRoleAsync(ljvdbb, "Administrator");

    }   
}