using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    
    public class CancelBookingDto
    {
        public Guid  FlightId { get; set; }
        public string PassengerEmail { get; set; }
        public int NumberOfSeats { get; set; }

        // Constructor for CancelBookingDto class
        public CancelBookingDto(
            Guid flightId,           // Unique identifier of the flight
        string passengerEmail,   // Email of the passenger whose booking is to be canceled
        int numberOfSeats        // Number of seats to cancel
            )
        {
            FlightId = flightId;
            PassengerEmail = passengerEmail;
            NumberOfSeats = numberOfSeats;
        }
    }
}
