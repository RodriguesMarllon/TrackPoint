using Domain.Entities.Clients;
using Domain.Entities.Employees;
using Domain.Entities.Projects;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Configuration
{
    public class TrackPointContext : DbContext
    {
        public TrackPointContext(DbContextOptions<TrackPointContext> options) : base(options)
        {
        }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
