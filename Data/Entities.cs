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
            // Configuring the primary key for the Flight entity
            modelBuilder.Entity<Flight>().HasKey(f => f.Id);
            // This sets the 'Id' property as the primary key for the Flight entity.
            // Having a primary key is essential for uniquely identifying each record in the database.

            // Configuring that Flight owns many Booking entities
            modelBuilder.Entity<Flight>().OwnsMany(f => f.BookingList);

            // Additional entity configurations can be added here if needed
            base.OnModelCreating(modelBuilder);
        }
    }
}
