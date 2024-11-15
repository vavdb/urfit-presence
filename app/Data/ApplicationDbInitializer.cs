﻿using Microsoft.AspNetCore.Identity;
using urfit_presence.Data;

public class ApplicationDbInitializer
{
    private readonly UserManager<ApplicationUser> userManager;
    private readonly RoleManager<IdentityRole> roleManager;

    public ApplicationDbInitializer(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
    {
        this.userManager = userManager;
        this.roleManager = roleManager;
    }
    public async Task SeedUsersAndRolesAsync()
    {
        
        string[] roles = new string[] { "Owner", "Administrator", "User", "Bootcamper" };

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
                        UserName = "vincent@urfit.nu",
                        Email = "vincent@urfit.nu",
                        EmailConfirmed = true
                    };

            var result = await userManager.CreateAsync(vavdb, "Dummy123!");
        }
        if (ljvdbb is null)
        {
            ljvdbb = new ApplicationUser
                     {
                         UserName = "leydi@urfit.nu",
                         Email = "leydi@urfit.nu",
                         EmailConfirmed = true
                     };

            var result = await userManager.CreateAsync(ljvdbb, "Dummy123!");
        }
        await userManager.AddToRoleAsync(vavdb, "Administrator");
        await userManager.AddToRoleAsync(ljvdbb, "Administrator");

    }   
}