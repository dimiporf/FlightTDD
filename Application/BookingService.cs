using Data;

namespace Application
{
    public class BookingService
    {
        public Entities Entities { get; set; }
        public BookingService(Entities entities)
        {
            Entities = entities;
        }

        // Simulates the booking process
        public void Book(BookDto bookDto)
        {
            // Retrieve the flight with the specified FlightId from the DbContext
            var flight = Entities.Flights.Find(bookDto.FlightId);

            // If the flight is found, reserve seats using the Book method and save changes to the database
            if (flight != null)
            {
                flight.Book(bookDto.PassengerEmail, bookDto.NumberOfSeats);
                Entities.SaveChanges();
            }
            // Note: In a real-world scenario, additional error handling and validation might be needed.
        }

        // Simulates finding bookings for a specific flight by its unique identifier (flightId)
        public IEnumerable<BookingRm> FindBookings(Guid flightId)
        {
            // Retrieve the flight with the specified flightId from the DbContext
            var flight = Entities.Flights.Find(flightId);

            // If the flight is found, map its BookingList to BookingRm objects and return the result
            return flight?.BookingList?.Select(booking => new BookingRm(
                booking.Email,
                booking.NumberOfSeats)
            ) ?? Enumerable.Empty<BookingRm>();
            // If the flight is not found or has no bookings, return an empty collection of BookingRm.
        }
    }
}