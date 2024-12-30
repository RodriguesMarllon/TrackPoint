using Domain.Entities.Clients;
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

        public DbSet<Client> Clients { get; set; }
        public DbSet<Project> Projects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            DefineForeignKeys(modelBuilder);
        }

        private void DefineForeignKeys(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                .HasOne<Client>()
                .WithMany()
                .HasForeignKey(p => p.ClientId);
        }
    }
}
