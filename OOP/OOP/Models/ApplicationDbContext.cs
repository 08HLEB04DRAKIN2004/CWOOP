using Microsoft.EntityFrameworkCore;
using OOP.Domain.Entity;

namespace OOP
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

            Database.EnsureCreated();
        }

        public DbSet<Client> clients { get; set; }
        public DbSet<Orders> orders { get; set; }
        public DbSet<Department> department { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<EmployeeInProject> employeesInProject { get; set; }
        public DbSet<MediaResource> mediaResources { get; set; }
        public DbSet<Project> projects { get; set; }
        public DbSet<ProjectRole> projectRoles { get; set; }

    }
}

