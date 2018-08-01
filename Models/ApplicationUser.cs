using Microsoft.AspNetCore.Identity;

namespace workOrderAPI.Models{
    public class ApplicationUser : IdentityUser{
        public string user { get; set; }
    }
}