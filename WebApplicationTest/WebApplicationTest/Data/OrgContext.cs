using Microsoft.EntityFrameworkCore;
using WebApplicationTest.Models;

public class OrgContext : DbContext
{
    public OrgContext(DbContextOptions<OrgContext> options) : base(options)
    {

    }

    //public int ID { get; set; }
    public DbSet<Organization> organizations { get; set; }
    public DbSet<Department> departments { get; set; }
    public DbSet<Employee> employees { get; set; }

}