using Microsoft.AspNetCore.Identity;

public static class ApplicationDbInitializer
{
    public static void SeedUsers(UserManager<IdentityUser> userManager)
    {
        if (userManager.FindByEmailAsync("vincent@urfit.nu").Result==null)
        {
            IdentityUser user = new IdentityUser
            {
                UserName = "vavdb",
                Email = "vincent@urfit.nu"
            };

            IdentityResult result = userManager.CreateAsync(user, "dummy").Result;

            if (result.Succeeded)
            {
                userManager.AddToRoleAsync(user, "Admin").Wait();
            }
        }       
    }   
}