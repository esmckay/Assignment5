using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Assignment5.Models
{
    public class SemiAdminDbContext : IdentityDbContext<IdentityUser>
    {
        public SemiAdminDbContext(DbContextOptions<SemiAdminDbContext> options)
            : base(options) { }
    }
}
