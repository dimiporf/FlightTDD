using Domain;
using FluentAssertions;

namespace Application.Tests
{
    public class FlightApplicationSpecifications
    {
        [Fact]
        public void Books_flights()
        {
            // Arrange: Create an instance of the Entities DbContext
            var entities = new Entities();

            //Declaring a new Flight into a variable for use into Arrange
            var flight = new Flight(3);

            // Arrange: Add a new Flight to the Flights DbSet in the DbContext
            entities.Flights.Add(flight);

            //entities.SaveChanges(); // Save changes to persist the new Flight


            // Arrange: Create an instance of the BookingService
            var bookingService = new BookingService(entities: entities);

            // Act: Invoke the Book method on the BookingService with a dummy BookDto
            bookingService.Book(new BookDto(
                flightId: flight.Id,
                passengerEmail: "dimiporf@live.com",
                numberOfSeats: 2
                ));

            // Assert: Check that the FindBookings method returns a collection containing an equivalent BookingRm object
            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
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
        public IEnumerable<BookingRm> FindBookings(Guid flightId)
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