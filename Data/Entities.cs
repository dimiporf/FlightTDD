using Domain;
using Microsoft.EntityFrameworkCore;

namespace Data
{
    public class Entities: DbContext
    {
        // DbSet property for the Flight entity
        public DbSet<Flight> Flights => Set<Flight>();
    }
}
