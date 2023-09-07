using Microsoft.AspNetCore.Identity;

namespace RoleIdentity.Models.Domain
{
    public class ApplicationUser:IdentityUser
    {
        public string? Name { get; set; }
        public string? ProfileImage { get; set; }
    }
}
