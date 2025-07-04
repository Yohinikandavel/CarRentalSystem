using System;
namespace CarRentalSystem.entity
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public string Make { get; set; } = "";
        public string Model { get; set; } = "";
        public int Year { get; set; }
        public double DailyRate { get; set; }
        public string Status { get; set; } = "";
        public int PassengerCapacity { get; set; }
        public float EngineCapacity { get; set; }

        // Default constructor
        public Vehicle() { }

        // Parameterized constructor
        public Vehicle(int vehicleID, string make, string model, int year, double dailyRate, string status, int passengerCapacity, float engineCapacity)
        {
            VehicleID = vehicleID;
            Make = make;
            Model = model;
            Year = year;
            DailyRate = dailyRate;
            Status = status;
            PassengerCapacity = passengerCapacity;
            EngineCapacity = engineCapacity;
        }

        public override string ToString()
        {
            return $"VehicleID: {VehicleID}, Make: {Make}, Model: {Model}, Year: {Year}, Status: {Status}, DailyRate: {DailyRate}, Capacity: {PassengerCapacity}, Engine: {EngineCapacity}";
        }

    }
    
}