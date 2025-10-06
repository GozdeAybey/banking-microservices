using Microsoft.AspNetCore.Identity;

namespace AuthService.Data
{
    public class AppUser : IdentityUser
    {
        public string FullName { get; set; }
    }
}