using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Entities: DbContext
    {
        public Entities(DbContextOptions options): base(options)
        {
            
        }
        // DbSet property for the Flight entity
        public DbSet<Flight> Flights => Set<Flight>();
    }
}
