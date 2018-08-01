using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace workOrderAPI.Models{
    public class UserDbContext : IdentityDbContext//removed IdentityUser in diamond
  {
    public UserDbContext(DbContextOptions<UserDbContext> options)
            : base(options)
    {
      Database.EnsureCreated();
    }
  }
}