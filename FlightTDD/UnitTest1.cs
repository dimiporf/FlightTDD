using Domain.Tests;
using FluentAssertions;

namespace FlightTDD
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var flight = new Flight(seatCapacity: 3);

            flight.Book("dimiporf@live.com", 1);

            flight.RemainingNumberOfSeats.Should().Be(2);

        }
    }
}