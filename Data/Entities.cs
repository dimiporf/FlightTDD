using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Entities: DbContext
    {
        // DbSet property for the Flight entity
        public DbSet<Flight> Flights => Set<Flight>();

        // Constructor to initialize DbContext with options
        public Entities(DbContextOptions options): base(options)
        {
            
        }

        // Method to configure entity mappings
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Flight>().HasKey(f => f.Id);

            // Additional entity configurations can be added here if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
