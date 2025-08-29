using Microsoft.EntityFrameworkCore;

namespace DepartmentAPI
{
    public class DepartmentContext : DbContext
    {
        public DepartmentContext(DbContextOptions<DepartmentContext> options)
            : base(options)
        {
        }

        public DbSet<Model> Departments { get; set; }
    }
}