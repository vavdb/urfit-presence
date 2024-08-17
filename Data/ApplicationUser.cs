using Microsoft.AspNetCore.Identity;

namespace urfit_presence.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ICollection<Presence> Presences { get; set; } = [];

    // public bool IsBootcamper { get; set; }
    public override string ToString()
    {
        return UserName;
    }
}