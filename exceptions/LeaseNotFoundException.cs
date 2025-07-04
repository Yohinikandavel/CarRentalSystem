using System;

namespace CarRentalSystem.exceptions
{
    public class LeaseNotFoundException : Exception
    {
        public LeaseNotFoundException(string message) : base(message)
        {
            Console.WriteLine($"LeaseNotFoundException: {message}");
        }
    }
}