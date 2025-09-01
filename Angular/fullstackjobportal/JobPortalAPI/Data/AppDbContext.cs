using Microsoft.EntityFrameworkCore;
using JobPortalAPI.Models;

namespace JobPortalAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<JobPosting> JobPostings { get; set; }
    }
}
