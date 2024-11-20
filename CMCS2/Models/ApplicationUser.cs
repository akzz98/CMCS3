using Microsoft.AspNetCore.Identity;

namespace CMCS2.Models
{
    public class ApplicationUser: IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
