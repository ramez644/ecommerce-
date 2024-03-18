using Microsoft.AspNetCore.Identity;

namespace Oseas.Models
{
    public class ApplicationUser:IdentityUser
    {

        public string Address { get; set; }
        
    }
}
