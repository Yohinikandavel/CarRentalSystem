using System;
namespace CarRentalSystem.entity
{
    public class Lease
    {
        public int LeaseID { get; set; }
        public int VehicleID { get; set; }
        public int CustomerID { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Type { get; set; } = "";

        // Default constructor
        public Lease() { }

        // Parameterized constructor
        public Lease(int leaseID, int vehicleID, int customerID, DateTime startDate, DateTime endDate, string type)
        {
            LeaseID = leaseID;
            VehicleID = vehicleID;
            CustomerID = customerID;
            StartDate = startDate;
            EndDate = endDate;
            Type = type;
        }
        public override string ToString()
        {
            return $"Lease ID: {LeaseID}, Vehicle ID: {VehicleID}, Customer ID: {CustomerID}, Start: {StartDate.ToShortDateString()}, End: {EndDate.ToShortDateString()}, Type: {Type}";
        }

    }
}