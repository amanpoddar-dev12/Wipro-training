using System;

namespace CarRentalSystem.Exceptions
{
    public class CarNotFoundException : Exception
    {
        public CarNotFoundException() { }

        public CarNotFoundException(string message) : base(message) { }

        public CarNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
