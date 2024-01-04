using Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests
{
    public class FlightApplicationSpecifications
    {
        [Theory]
        [InlineData("dimiporf@live.com", 2)]
        [InlineData("porfidim@live.com", 2)]
        public void Books_flights(string passengerEmail, int numberOfSeats)
        {
            // Arrange: Create an instance of the Entities DbContext
            var entities = new Entities(new DbContextOptionsBuilder<Entities>()
                .UseInMemoryDatabase("Flights")
                .Options);

            //Declaring a new Flight into a variable for use into Arrange
            var flight = new Flight(3);

            // Arrange: Add a new Flight to the Flights DbSet in the DbContext
            entities.Flights.Add(flight);

            
            // Arrange: Create an instance of the BookingService
            var bookingService = new BookingService(entities);

            // Act: Invoke the Book method on the BookingService with a dummy BookDto
            bookingService.Book(new BookDto(
                flightId: flight.Id,
                passengerEmail,
                numberOfSeats
                ));

            // Assert: Check that the FindBookings method returns a collection containing an equivalent BookingRm object
            bookingService.FindBookings(flight.Id).Should().ContainEquivalentOf(
                new BookingRm(
                    passengerEmail,
                numberOfSeats
                    )
                );
        }

    }

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

    public class BookDto
    {
        public Guid FlightId { get; set; }
        public string PassengerEmail { get; set; }

        public  int NumberOfSeats { get; set; }
        // Placeholder for data transfer object used in the booking process
        public BookDto(Guid flightId, string passengerEmail, int numberOfSeats)
        {
            FlightId = flightId;
            PassengerEmail = passengerEmail;
            NumberOfSeats = numberOfSeats;
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