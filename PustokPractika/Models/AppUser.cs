using Microsoft.AspNetCore.Identity;

namespace PustokPractika.Models
{
    public class AppUser:IdentityUser
    {
        public string Name { get; set; }
        public string Surname { get; set; } 
        public bool IsReminded { get; set; }    
        public string Gender { get; set; }  
    }
}
