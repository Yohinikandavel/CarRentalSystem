using System;
using CarRentalSystem.dao;
using CarRentalSystem.entity;
using CarRentalSystem.exceptions;
using CarRentalSystem.util;

namespace CarRentalSystem
{
    public class MainModule
    {
        public static void Main(string[] args)
        {
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                Console.WriteLine(" Database connection successful!");
            }

            ICarLeaseRepository repo = new CarLeaseRepositoryImpl();

            while (true)
            {
                Console.WriteLine("Welcome to the Car Rental System!");
                Console.WriteLine("========= MENU =============");
                Console.WriteLine("1. Vehicle Management");
                Console.WriteLine("2. Customer Management");
                Console.WriteLine("3. Lease Management");
                Console.WriteLine("4. Payment Management");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice (1-5): ");
                var choice = Console.ReadLine();
                Console.WriteLine();
                try
                {
                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine("Vehicle Management selected.");
                            Console.WriteLine();
                            Console.WriteLine("Select an option:");
                            Console.WriteLine("1. Add Vehicle");
                            Console.WriteLine("2. Get Vehicle Details");
                            Console.WriteLine("3. Update Vehicle");
                            Console.WriteLine("4. Delete Vehicle");
                            Console.WriteLine("5. Back to Main Menu");
                            string? vehicleOption = Console.ReadLine();
                            switch (vehicleOption)
                            {
                                case "1":
                                    Console.WriteLine("Enter vehicle details:");
                                    Console.WriteLine();
                                    Console.Write("Make:");
                                    string? make = Console.ReadLine();
                                    Console.Write("Model:");
                                    string? model = Console.ReadLine();
                                    Console.Write("Year:");
                                    int year = int.Parse(Console.ReadLine());
                                    Console.Write("Status:");
                                    string? status = Console.ReadLine();
                                    Console.Write("Passenger Capacity:");
                                    int passengerCapacity = int.Parse(Console.ReadLine());
                                    Console.Write("Engine Capacity:");
                                    float engineCapacity = float.Parse(Console.ReadLine());
                                    Vehicle newVehicle = new Vehicle
                                    {
                                        Make = make,
                                        Model = model,
                                        Year = year,
                                        Status = status,
                                        PassengerCapacity = passengerCapacity,
                                        EngineCapacity = engineCapacity,
                                        DailyRate = 2500.0 // Default daily rate, can be modified later
                                    };
                                    repo.AddVehicle(newVehicle);
                                    Console.WriteLine("Vehicle added Successfully!!");
                                    Console.WriteLine();
                                    break;

                                case "2":
                                    Console.Write("Enter vehicle ID to get details:");
                                    int vehicleID = int.Parse(Console.ReadLine());
                                    Vehicle vehicle = repo.GetVehicleById(vehicleID);
                                    Console.WriteLine(vehicle);
                                    Console.WriteLine($"Vehicle details for ID {vehicleID} retrieved successfully.");
                                    Console.WriteLine();
                                    break;

                                case "3":
                                    Console.WriteLine("Enter vehicle ID to update:");
                                    int updateVehicleID = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.WriteLine("Enter new details:");
                                    Console.WriteLine("Make:");
                                    string? newMake = Console.ReadLine();
                                    Console.WriteLine("Model:");
                                    string? newModel = Console.ReadLine();
                                    Console.WriteLine("Year:");
                                    int newYear = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Status:");
                                    string? newStatus = Console.ReadLine();
                                    Console.WriteLine("Passenger Capacity:");
                                    int newPassengerCapacity = int.Parse(Console.ReadLine());
                                    Console.WriteLine("Engine Capacity:");
                                    float newEngineCapacity = float.Parse(Console.ReadLine());

                                    Vehicle updatedVehicle = new Vehicle
                                    {
                                        VehicleID = updateVehicleID,
                                        Make = newMake,
                                        Model = newModel,
                                        Year = newYear,
                                        Status = newStatus,
                                        PassengerCapacity = newPassengerCapacity,
                                        EngineCapacity = newEngineCapacity,
                                        DailyRate = 2500.0 // Default daily rate, can be modified later
                                    };
                                    break;

                                case "4":
                                    Console.Write("Enter vehicle ID to delete:");
                                    int deleteVehicleID = int.Parse(Console.ReadLine());
                                    repo.DeleteVehicle(deleteVehicleID);
                                    Console.WriteLine("Vehicle deleted successfully.");
                                    Console.WriteLine();
                                    break;

                                case "5":
                                    Console.WriteLine("Returning to Main Menu...");
                                    Console.WriteLine();
                                    break;

                                default:
                                    Console.WriteLine("Invalid option selected. Please try again.");
                                    Console.WriteLine();
                                    break;
                            }
                            break;

                        case "2":
                            Console.WriteLine("Customer Management selected.");
                            Console.WriteLine();
                            Console.WriteLine("Select an option:");
                            Console.WriteLine("1. Add Customer");
                            Console.WriteLine("2. Get Customer Details");
                            Console.WriteLine("3. Update Customer");
                            Console.WriteLine("4. Delete Customer");
                            Console.WriteLine("5. Back to Main Menu");
                            string? customerOption = Console.ReadLine();
                            switch (customerOption)
                            {
                                case "1":
                                    Console.WriteLine("Enter customer details:");
                                    Console.WriteLine();
                                    Console.Write("First Name:");
                                    string? firstName = Console.ReadLine();
                                    Console.Write("Last Name:");
                                    string? lastName = Console.ReadLine();
                                    Console.Write("Email:");
                                    string? email = Console.ReadLine();
                                    Console.Write("Phone Number:");
                                    string? phoneNumber = Console.ReadLine();

                                    Console.WriteLine($"Customer added: {firstName} {lastName}, Email: {email}, Phone: {phoneNumber}");
                                    Console.WriteLine("Customer added Successfully!!");
                                    Console.WriteLine();
                                    break;

                                case "2":
                                    Console.Write("Enter customer ID to get details:");
                                    int customerID = int.Parse(Console.ReadLine());
                                    Customer customer = repo.GetCustomerById(customerID);
                                    Console.WriteLine(customer);
                                    Console.WriteLine($"Customer details for ID {customerID} retrieved successfully.");
                                    Console.WriteLine();
                                    break;

                                case "3":
                                    Console.Write("Enter customer ID to update:");
                                    int updateCustomerID = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.WriteLine("Enter new details:");
                                    Console.Write("First Name:");
                                    string? newFirstName = Console.ReadLine();
                                    Console.Write("Last Name:");
                                    string? newLastName = Console.ReadLine();
                                    Console.Write("Email:");
                                    string? newEmail = Console.ReadLine();
                                    Console.Write("Phone Number:");
                                    string? newPhoneNumber = Console.ReadLine();

                                    Console.WriteLine($"Customer with ID {updateCustomerID} updated successfully.");
                                    Console.WriteLine();
                                    break;

                                case "4":
                                    Console.Write("Enter customer ID to delete:");
                                    int deleteCustomerID = int.Parse(Console.ReadLine());
                                    Console.WriteLine($"Customer with ID {deleteCustomerID} deleted successfully.");
                                    Console.WriteLine();
                                    break;

                                case "5":
                                    Console.WriteLine("Returning to Main Menu...");
                                    Console.WriteLine();
                                    break;

                                default:
                                    Console.WriteLine("Invalid option selected. Please try again.");
                                    Console.WriteLine();
                                    break;
                            }
                            break;

                        case "3":
                            Console.WriteLine("Lease Management selected.");
                            Console.WriteLine();
                            Console.WriteLine("Select an option:");
                            Console.WriteLine("1. Create Lease");
                            Console.WriteLine("2. Get Lease Details");
                            Console.WriteLine("3. Update Lease");
                            Console.WriteLine("4. Delete Lease");
                            Console.WriteLine("5. Back to Main Menu");
                            string? leaseOption = Console.ReadLine();
                            switch (leaseOption)
                            {
                                case "1":
                                    Console.WriteLine("Enter lease details:");
                                    Console.WriteLine();
                                    Console.Write("Vehicle ID:");
                                    int leaseVehicleID = int.Parse(Console.ReadLine());
                                    Console.Write("Customer ID:");
                                    int leaseCustomerID = int.Parse(Console.ReadLine());
                                    Console.Write("Start Date (yyyy-mm-dd):");
                                    DateTime startDate = DateTime.Parse(Console.ReadLine());
                                    Console.Write("End Date (yyyy-mm-dd):");
                                    DateTime endDate = DateTime.Parse(Console.ReadLine());
                                    Console.Write("Lease Type:");
                                    string? leaseType = Console.ReadLine();

                                    Console.WriteLine($"Lease created for Vehicle ID {leaseVehicleID}, Customer ID {leaseCustomerID}, Start Date: {startDate}, End Date: {endDate}, Type: {leaseType}");
                                    Console.WriteLine("Lease created Successfully!!");
                                    Console.WriteLine();
                                    break;

                                case "2":
                                    Console.Write("Enter lease ID to get details:");
                                    int leaseID = int.Parse(Console.ReadLine());
                                    Lease lease = repo.GetLeaseById(leaseID);
                                    Console.WriteLine(lease);
                                    Console.WriteLine($"Lease details for ID {leaseID} retrieved successfully.");
                                    Console.WriteLine();
                                    break;

                                case "3":
                                    Console.Write("Enter lease ID to update:");
                                    int updateLeaseID = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.WriteLine("Enter new details:");
                                    Console.Write("Start Date (yyyy-mm-dd):");
                                    DateTime newStartDate = DateTime.Parse(Console.ReadLine());
                                    Console.Write("End Date (yyyy-mm-dd):");
                                    DateTime newEndDate = DateTime.Parse(Console.ReadLine());
                                    Console.Write("Lease Type:");
                                    string? newLeaseType = Console.ReadLine();

                                    Console.WriteLine($"Lease with ID {updateLeaseID} updated successfully.");
                                    Console.WriteLine();
                                    break;

                                case "4":
                                    Console.Write("Enter lease ID to delete:");
                                    int deleteLeaseID = int.Parse(Console.ReadLine());
                                    Console.WriteLine($"Lease with ID {deleteLeaseID} deleted successfully.");
                                    Console.WriteLine();
                                    break;

                                case "5":
                                    Console.WriteLine("Returning to Main Menu...");
                                    Console.WriteLine();
                                    break;

                                default:
                                    Console.WriteLine("Invalid option selected. Please try again.");
                                    Console.WriteLine();
                                    break;
                            }
                            break;

                        case "4":
                            Console.WriteLine("Payment Management selected.");
                            Console.WriteLine();
                            Console.WriteLine("Select an option:");
                            Console.WriteLine("1. Add Payment");
                            Console.WriteLine("2. Get Payment Details");
                            Console.WriteLine("3. Update Payment");
                            Console.WriteLine("4. Delete Payment");
                            Console.WriteLine("5. Back to Main Menu");
                            string? paymentOption = Console.ReadLine();
                            switch (paymentOption)
                            {
                                case "1":
                                    Console.WriteLine("Enter payment details:");
                                    Console.WriteLine();
                                    Console.Write("Lease ID:");
                                    int paymentLeaseID = int.Parse(Console.ReadLine());
                                    Console.Write("Payment Date (yyyy-mm-dd):");
                                    DateTime paymentDate = DateTime.Parse(Console.ReadLine());
                                    Console.Write("Amount:");
                                    double amount = double.Parse(Console.ReadLine());

                                    Console.WriteLine($"Payment added for Lease ID {paymentLeaseID}, Date: {paymentDate}, Amount: {amount}");
                                    Console.WriteLine("Payment added Successfully!!");
                                    Console.WriteLine();
                                    break;

                                case "2":
                                    Console.WriteLine("Please enter payment ID to get details:");
                                    int paymentID = int.Parse(Console.ReadLine());
                                    Payment payment = repo.GetPaymentById(paymentID);
                                    Console.WriteLine(payment);
                                    Console.WriteLine($"Payment details for ID {paymentID} retrieved successfully.");
                                    Console.WriteLine();
                                    break;

                                case "3":
                                    Console.WriteLine("Please enter payment ID to update:");
                                    int updatePaymentID = int.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    Console.WriteLine("Enter new details:");
                                    Console.Write("Payment Date (yyyy-mm-dd):");
                                    DateTime newPaymentDate = DateTime.Parse(Console.ReadLine());
                                    Console.Write("Amount:");
                                    double newAmount = double.Parse(Console.ReadLine());

                                    Console.WriteLine($"Payment with ID {updatePaymentID} updated successfully.");
                                    Console.WriteLine();
                                    break;

                                case "4":
                                    Console.WriteLine("Please enter payment ID to delete:");
                                    int deletePaymentID = int.Parse(Console.ReadLine());
                                    Console.WriteLine($"Payment with ID {deletePaymentID} deleted successfully.");
                                    Console.WriteLine();
                                    break;

                                case "5":
                                    Console.WriteLine("Returning to Main Menu...");
                                    Console.WriteLine();
                                    break;

                                default:
                                    Console.WriteLine("Invalid option selected. Please try again.");
                                    Console.WriteLine();
                                    break;
                            }
                            break;

                        case "5":
                            Console.WriteLine("Exiting the Car Rental System. Thank you!");
                            Environment.Exit(0);
                            break;

                        default:
                            Console.WriteLine("Invalid option selected. Please try again.");
                            Console.WriteLine();
                            break;

                    }
                }
                catch (FormatException ex)
                {
                    Console.WriteLine("Invalid input format. Please enter the correct data type.");
                    Console.WriteLine($"Error: {ex.Message}");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("An error occurred. Please try again.");
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }
    
    }
}
