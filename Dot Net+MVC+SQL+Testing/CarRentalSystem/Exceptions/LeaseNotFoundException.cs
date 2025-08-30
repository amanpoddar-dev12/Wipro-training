using System;

namespace CarRentalSystem.Exceptions
{
    public class LeaseNotFoundException : Exception
    {
        public LeaseNotFoundException() { }

        public LeaseNotFoundException(string message) : base(message) { }

        public LeaseNotFoundException(string message, Exception inner) : base(message, inner) { }
    }
}
