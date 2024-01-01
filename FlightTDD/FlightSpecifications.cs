using Domain;
using FluentAssertions;

namespace FlightTDD
{
    public class FlightSpecifications
    {
        // Parameterized test to verify that booking reduces the number of seats correctly
        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(6, 3, 3)]
        [InlineData(10, 6, 4)]
        public void Booking_reduces_the_number_of_seats_Parameterized(int seatCapacity, int numberOfSeats, int remainingNumberOfSeats)
        {
            // Arrange: Create a flight with the specified seat capacity
            var flight = new Flight(seatCapacity: seatCapacity);

            // Act: Book a specific number of seats
            flight.Book("dimiporf@live.com", numberOfSeats);

            // Assert: Check that the remaining number of seats matches the expected value
            flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfSeats);
        }

        // Test to verify that booking reduces the number of seats
        [Fact]
        public void Booking_reduces_the_number_of_seats()
        {
            // Arrange: Create a flight with a seat capacity of 3
            var flight = new Flight(seatCapacity: 3);

            // Act: Book 1 seat
            flight.Book("dimiporf@live.com", 1);

            // Assert: Check that the remaining number of seats is 2
            flight.RemainingNumberOfSeats.Should().Be(2);
        }

        // Similar tests for different scenarios...

        // Test to verify that overbooking is avoided
        [Fact]
        public void Avoids_overbooking()
        {
            // Given: Create a flight with a seat capacity of 3
            var flight = new Flight(seatCapacity: 3);

            // When: Attempt to book more seats than the capacity
            var error = flight.Book("dimiporf@live.com", 4);

            // Then: Check that an OverbookingError is returned
            error.Should().BeOfType<OverbookingError>();
        }

        // Test to verify that flights are booked successfully
        [Fact]
        public void Books_flights_successfully()
        {
            // Arrange: Create a flight with a seat capacity of 3
            var flight = new Flight(seatCapacity: 3);

            // Act: Attempt to book 1 seat
            var error = flight.Book("dimiporf@live.com", 1);

            // Assert: Check that no error is returned (booking successful)
            error.Should().BeNull();
        }

        // Test to verify that the flight remembers bookings
        [Fact]
        public void Remembers_bookings()
        {
            // Arrange: Create a flight with a seat capacity of 150
            var flight = new Flight(seatCapacity: 150);

            // Act: Book 4 seats
            flight.Book(passengerEmail: "dimiporf@live.com", numberOfSeats: 4);

            // Assert: Check that the booking list contains an equivalent booking
            flight.BookingList.Should().ContainEquivalentOf(new Booking("dimiporf@live.com", 4));
        }

        [Theory]
        [InlineData(3,1,1,3)]
        [InlineData(4, 2, 2, 4)]
        [InlineData(7, 5, 4, 6)]
        public void Canceling_bookings_frees_up_the_seats(
            int initialCapacity,
            int numberOfSeatsToBook,
            int numberOfSeatsToCancel,
            int remainingNumberOfSeats
            )
        {
            // Arrange: Create a flight with the specified initial capacity
            var flight = new Flight(initialCapacity);

            // Act: Book a certain number of seats
            flight.Book(passengerEmail: "dimiporf@live.com", numberOfSeats: numberOfSeatsToBook);

            // Act: Cancel a certain number of seats
            flight.CancelBooking(passengerEmail: "dimiporf@live.com", numberOfSeats: numberOfSeatsToCancel);

            // Assert: Check that the remaining number of seats matches the expected value
            flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfSeats);
        }

        [Fact]
        public void Doesnt_cancel_bookings_for_passengers_who_have_not_booked()
        {
            var flight = new Flight(3);

            var error = flight.CancelBooking(passengerEmail: "porfiro@ro.com", numberOfSeats: 2);

            error.Should().BeOfType<BookingNotFoundError>();
        }

    }
}
