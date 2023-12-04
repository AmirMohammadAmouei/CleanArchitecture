using HR.LeaveManagement.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace HR.LeaveManagement.Identity.DBContext
{
    public class HRDBContext : IdentityDbContext<ApplicationUser>
    {
        public HRDBContext(DbContextOptions<HRDBContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                var connectionString =
                    "Server=.\\AMIR; Initial Catalog=HRLeaveManagementIdentity ; User Id=AmirFar ; Password=73719199";
                optionsBuilder.UseSqlServer(connectionString);
            }
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(HRDBContext).Assembly); 
            base.OnModelCreating(builder);
        }
    }
}
