using Microsoft.EntityFrameworkCore;

namespace process.Models
{

    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Element> Element { get; set; }
        public DbSet<Flow> Flow { get; set; }
        public DbSet<Report> Report { get; set; }


    }
}
