using Microsoft.AspNetCore.Identity;

namespace urfit_presence.Data;

// Add profile data for application users by adding properties to the ApplicationUser class
public class ApplicationUser : IdentityUser
{
    public ICollection<Presence> Presences { get; set; } = [];
    public string? InformationRelationId { get; set; }

    public string? FirstName { get; set; }
    public string? SurNamePrefix { get; set; }
    public string? SurName { get; set; }

    public override string ToString()
    {
        var r = ((FirstName?.Trim() + " " + SurNamePrefix?.Trim()).Trim() + " " + SurName?.Trim());
        if (string.IsNullOrWhiteSpace(r))
        {
            r = UserName;
        }

        return r;
    }
}