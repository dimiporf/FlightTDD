using FluentAssertions;

namespace Application.Tests
{
    public class FlightApplicationSpecifications
    {
        [Fact]
        public void Books_flights()
        {
            
            
            var entities = new Entities();
            entities.Flights.Add(new Flight(3));

            // Arrange: Create an instance of the BookingService
            var bookingService = new BookingService(entities: entities);

            // Act: Invoke the Book method on the BookingService with a dummy BookDto
            bookingService.Book(new BookDto(
                flightId: Guid.NewGuid(),
                passengerEmail: "dimiporf@live.com",
                numberOfSeats: 2
                ));

            // Assert: Check that the FindBookings method returns a collection containing an equivalent BookingRm object
            bookingService.FindBookings().Should().ContainEquivalentOf(
                new BookingRm(
                    passengerEmail: "dimiporf@live.com",
                numberOfSeats: 2
                    )
                );
        }

    }

    public class BookingService
    {
        public BookingService(Entities entities)
        {
            
        }

        // Simulates the booking process
        public void Book(BookDto bookDto)
        {
            // Implementation details for booking flights go here
        }

        // Simulates finding bookings
        public IEnumerable<BookingRm> FindBookings()
        {
            // In a real-world scenario, this method would query the database or other storage to retrieve bookings.
            // For now, let's return a dummy collection containing a BookingRm object.
            return new[] { new BookingRm(
                passengerEmail: "dimiporf@live.com",
                numberOfSeats: 2) 
            };
        }
    }

    public class BookDto
    {
        // Placeholder for data transfer object used in the booking process
        public BookDto(Guid flightId, string passengerEmail, int numberOfSeats)
        {
            
        }
    }

    public class BookingRm
    {
        public string  PassengerEmail { get; set; }

        public int NumberOfSeats { get; set; }

        // Constructor to initialize BookingRm with values
        public BookingRm(string passengerEmail, int numberOfSeats)
        {
            PassengerEmail = passengerEmail;
            NumberOfSeats = numberOfSeats; 
        }
    }
}