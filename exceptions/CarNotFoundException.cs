using System;

namespace CarRentalSystem.exceptions
{
    public class CarNotFoundException : Exception
    {
        public CarNotFoundException(string message) : base(message)
        {
            Console.WriteLine($"CarNotFoundException: {message}");
        }
    }
}