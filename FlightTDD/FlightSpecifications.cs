using Domain;
using FluentAssertions;

namespace FlightTDD
{
    public class FlightSpecifications
    {
        [Theory]
        [InlineData(3, 1, 2)]
        [InlineData(6, 3, 3)]
        [InlineData(10, 6, 4)]
        public void Booking_reduces_the_number_of_seats_Parameterized(int seatCapacity, int numberOfSeats, int remainingNumberOfSeats)
        {
            var flight = new Flight(seatCapacity: seatCapacity);

            flight.Book("dimiporf@live.com", numberOfSeats);

            flight.RemainingNumberOfSeats.Should().Be(remainingNumberOfSeats);

        }

        [Fact]
        public void Booking_reduces_the_number_of_seats()
        {
            var flight = new Flight(seatCapacity: 3);

            flight.Book("dimiporf@live.com", 1);

            flight.RemainingNumberOfSeats.Should().Be(2);

        }

        [Fact]
        public void Booking_reduces_the_number_of_seats_2()
        {
            var flight = new Flight(seatCapacity: 6);

            flight.Book("dimiporf@live.com", 3);

            flight.RemainingNumberOfSeats.Should().Be(3);

        }

        [Fact]
        public void Booking_reduces_the_number_of_seats_3()
        {
            var flight = new Flight(seatCapacity: 10);

            flight.Book("dimiporf@live.com", 6);

            flight.RemainingNumberOfSeats.Should().Be(4);

        }

        [Fact]
        public void Avoids_overbooking()
        {
            //Given
            var flight = new Flight(seatCapacity: 3);

            //When
            var error = flight.Book("dimiporf@live.com", 4);

            //Then
            error.Should().BeOfType<OverbookingError>();
        }

        [Fact]
        public void Books_flights_successfully()
        {
            var flight = new Flight(seatCapacity: 3);
            var error = flight.Book("dimiporf@live.com", 1);
            error.Should().BeNull();
        }
    }
}