using System;
namespace CarRentalSystem.entity
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; } = "";
        public string LastName { get; set; } = "";
        public string Email { get; set; } = "";
        public string PhoneNumber { get; set; } = "";

        // Default constructor
        public Customer() { }

        // Parameterized constructor
        public Customer(int customerID, string firstName, string lastName, string email, string phoneNumber)
        {
            CustomerID = customerID;
            FirstName = firstName;
            LastName = lastName;
            Email = email;
            PhoneNumber = phoneNumber;
        }
        public override string ToString()
        {
            return $"Customer ID: {CustomerID}, Name: {FirstName} {LastName}, Email: {Email}, Phone: {PhoneNumber}";
        }

    }
}