using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    // Represents a Booking Resource Model (BookingRm) with passenger email and number of seats
    public class BookingRm
    {
        // Gets or sets the passenger's email associated with the booking
        public string PassengerEmail { get; set; }

        // Gets or sets the number of seats booked
        public int NumberOfSeats { get; set; }

        // Constructor to initialize BookingRm with values
        public BookingRm(string passengerEmail, int numberOfSeats)
        {
            // Initialize the PassengerEmail property with the provided passengerEmail
            PassengerEmail = passengerEmail;

            // Initialize the NumberOfSeats property with the provided numberOfSeats
            NumberOfSeats = numberOfSeats;
        }
    }
}
