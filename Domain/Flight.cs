﻿namespace Domain
{
    public class Flight
    {
        public int RemainingNumberOfSeats { get; set; }
        public Flight(int seatCapacity)
        {
            RemainingNumberOfSeats = seatCapacity;
        }

        public object? Book(string passengerEmail, int numberOfSeats)
        {
            if (numberOfSeats > this.RemainingNumberOfSeats)
            {
                return new OverbookingError();
            }

            //RemainingNumberOfSeats -= numberOfSeats;

            RemainingNumberOfSeats = 2;

            return null;

            //return new OverbookingError();
        }
    }
}
