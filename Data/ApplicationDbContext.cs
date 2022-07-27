global using Microsoft.EntityFrameworkCore;
using jobPortal.Entities;

namespace jobPortal.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Job> job { get; set; }

        public DbSet<Company> company { get; set; }

        public DbSet<Candidate> candidate { get; set; }

        public DbSet<AppliedJob> appliedJob { get; set; }
    }

}