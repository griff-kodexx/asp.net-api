using Microsoft.AspNetCore.Identity;

namespace workOrderAPI.Models{
    public class ApplicationRole : IdentityRole{
        public string role { get; set; }

    }
}