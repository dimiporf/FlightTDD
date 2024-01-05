using Application.Tests;
using Domain;
using FluentAssertions;
using Microsoft.EntityFrameworkCore;

namespace Application.Tests
{
    public class FlightApplicationSpecifications
    {
        // (Moved here after refactoring -->
        // Arrange: Create an instance of the Entities DbContext
        readonly Entities entities = new Entities(new DbContextOptionsBuilder<Entities>()
                .UseInMemoryDatabase("Flights")
                .Options);

        readonly BookingService bookingService;
        public FlightApplicationSpecifications()
        {
            bookingService = new BookingService(entities: entities);
        }


        [Theory]
        [InlineData("dimiporf@live.com", 2)]
        [InlineData("porfidim@live.com", 2)]
        public void Remembers_bookings(string passengerEmail, int numberOfSeats)
        {

            //Declaring a new Flight into a variable for use into Arrange
            var flight = new Flight(3);

            // Arrange: Add a new Flight to the Flights DbSet in the DbContext
            entities.Flights.Add(flight);


            // Arrange: Create an instance of the BookingService
            // var bookingService = new BookingService(entities);
            // Moved outside of this scope for shared use

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

        [Theory]
        [InlineData(3)]
        [InlineData(10)]
        [InlineData(7)]
        public void Frees_up_seats_after_booking(int initialCapacity)
        {
            // Given
            // Arrange: Create an instance of the Entities DbContext
            // (var entities = new Entities(new DbContextOptionsBuilder<Entities>()
            //    .UseInMemoryDatabase("Flights")
            //    .Options);
            // Moved outside of this scope for shared use

            var flight = new Flight(initialCapacity);
            entities.Flights.Add(flight);

            // Moved outside of this scope for shared use
            // var bookingService = new BookingService(entities);

            // Act: Book seats on the flight
            bookingService.Book(new BookDto(
                flightId: flight.Id,
                passengerEmail: "dimiporf@live.com",
                numberOfSeats: 2));

            // When: Cancel booked seats
            bookingService.CancelBooking(
                new CancelBookingDto(
                    flightId: flight.Id,
                    passengerEmail: "dimiporf@live.com",
                    numberOfSeats: 2)
                );

            // Then: Verify the remaining number of seats
            bookingService.GetRemainingNumberOfSeatsFor(flight.Id)
                .Should().Be(initialCapacity);
        }
    }

    }



