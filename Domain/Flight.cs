namespace Domain
{
    public class Flight
    {
        public List<Booking> BookingList { get; set; } = new List<Booking>();

        // The number of remaining seats on the flight
        public int RemainingNumberOfSeats { get; set; }

        // Constructor to initialize the flight with a given seat capacity
        public Flight(int seatCapacity)
        {
            RemainingNumberOfSeats = seatCapacity;
        }

        // Method to book a certain number of seats for a passenger
        public object? Book(string passengerEmail, int numberOfSeats)
        {
            // Check if there are enough remaining seats to accommodate the booking
            if (numberOfSeats > this.RemainingNumberOfSeats)
            {
                // Return an OverbookingError if there are not enough seats
                return new OverbookingError();
            }

            // Reduce the number of remaining seats based on the booking
            RemainingNumberOfSeats -= numberOfSeats;

            BookingList.Add(new Booking(passengerEmail, numberOfSeats));

            // Devil's Advocate examples (commented out for normal functionality)
            // Uncomment these lines to simulate alternative scenarios for testing

            // Devil's Advocate example #1
            // return new OverbookingError();

            // Devil's Advocate example #2
            // RemainingNumberOfSeats = 2;

            // Devil's Advocate example #3
            // if (numberOfSeats == 1) RemainingNumberOfSeats = 2;
            // if (numberOfSeats == 3) RemainingNumberOfSeats = 3;

            // Return null indicating a successful booking
            return null;
        }
    }
}
