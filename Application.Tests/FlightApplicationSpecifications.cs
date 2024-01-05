using Application.Tests;
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
}



