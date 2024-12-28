using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Infraestructure.Configuration
{
    public class TrackPointContext : DbContext
    {
        public TrackPointContext(DbContextOptions<TrackPointContext> options)
        {
            this.Database.Migrate();
        }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
