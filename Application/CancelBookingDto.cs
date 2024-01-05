using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    
    public class CancelBookingDto
    {
        // Constructor for CancelBookingDto class
        public CancelBookingDto(
            Guid flightId,           // Unique identifier of the flight
        string passengerEmail,   // Email of the passenger whose booking is to be canceled
        int numberOfSeats        // Number of seats to cancel
            )
        {

        }
    }
}
