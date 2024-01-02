
namespace Domain
{
    public class Flight
    {
        // List to store booking information for the flight
        List<Booking> bookingList = new();

        // Public property exposing the booking list (read-only)
        public IEnumerable<Booking> BookingList => bookingList;
        

        //This is the old instanciation of BookingList before refactoring
        //public List<Booking> BookingList { get; set; } = new List<Booking>();

        // The number of remaining seats on the flight
        public int RemainingNumberOfSeats { get; set; }

        public Guid Id { get; } // Add the Id property

        // Constructor to initialize the flight with a given seat capacity
        public Flight(int seatCapacity)
        {
            RemainingNumberOfSeats = seatCapacity;
        }
        //Empty contructor for use InMemory DbContext
        Flight() { }

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

            // Add a new booking to the booking list
            bookingList.Add(new Booking(passengerEmail, numberOfSeats));

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

        public object? CancelBooking(string passengerEmail, int numberOfSeats)
        {

            // Additionally, returning a new BookingNotFoundError as a placeholder for the error scenario.
            if (!bookingList.Any(booking => booking.Email == passengerEmail))
                return new BookingNotFoundError();
            
            
            
            // Increase the remaining number of seats by the number of seats being canceled
            RemainingNumberOfSeats += numberOfSeats;
            // Note: In a real-world scenario, you might want to include additional logic or validation here.
            // For example, checking if the passengerEmail corresponds to an existing booking,
            // and handling cases where the numberOfSeats to cancel is greater than the booked seats.
            // This comment is just a placeholder for such considerations.


            // Remake the outcome of the initial return to null, so the logic is implemented.
            return null;
        }

        
    }
}
