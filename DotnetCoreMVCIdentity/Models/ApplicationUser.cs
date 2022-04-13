using Microsoft.AspNetCore.Identity;

namespace DotnetCoreMVCIdentity.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime? DoB { get; set; }
    }
}
