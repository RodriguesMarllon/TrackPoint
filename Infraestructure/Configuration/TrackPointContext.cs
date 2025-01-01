using Domain.Entities.Activities;
using Domain.Entities.Clients;
using Domain.Entities.Employees;
using Domain.Entities.Projects;
using Domain.Entities.WorkLogs;
using Microsoft.EntityFrameworkCore;

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
        public DbSet<WorkLog> WorkLogs { get; set; }
        public DbSet<Activity> Activities { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
