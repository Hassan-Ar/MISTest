

using Microsoft.AspNetCore.Identity;

namespace Demo.RealestateApp.Identity.Model
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
    }
}
