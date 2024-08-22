using Microsoft.EntityFrameworkCore;

namespace process.Models
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<vwelementposition> vwelementposition { get; set; }
        public DbSet<vwflowposition> vwflowposition { get; set; }

    }
}
