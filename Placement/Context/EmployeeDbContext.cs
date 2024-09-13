using Microsoft.EntityFrameworkCore;

namespace Placement.Models
{
    public class EmployeeDbContext : DbContext 
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) 
        {
        }
        public DbSet<Employee> Employee { get; set; } 
    }
   
}
