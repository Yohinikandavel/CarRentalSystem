using System;
using CarRentalSystem.entity;
using CarRentalSystem.util;
using CarRentalSystem.exceptions;
using Microsoft.Data.SqlClient;

namespace CarRentalSystem.dao
{
    public class CarLeaseRepositoryImpl : ICarLeaseRepository
    {
        public void AddVehicle(Vehicle vehicle)
        {
            // Code to add a vehicle
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Vehicle (make, model, year, dailyRate, status, passengerCapacity, engineCapacity) VALUES (@make, @model, @year, @dailyRate, @status, @passengerCapacity, @engineCapacity)", connection);
                command.Parameters.AddWithValue("@make", vehicle.Make);
                command.Parameters.AddWithValue("@model", vehicle.Model);
                command.Parameters.AddWithValue("@year", vehicle.Year);
                command.Parameters.AddWithValue("@dailyRate", vehicle.DailyRate);
                command.Parameters.AddWithValue("@status", vehicle.Status);
                command.Parameters.AddWithValue("@passengerCapacity", vehicle.PassengerCapacity);
                command.Parameters.AddWithValue("@engineCapacity", vehicle.EngineCapacity);
                command.ExecuteNonQuery();
            }
        }

        public Vehicle GetVehicleById(int vehicleId)
{
    using (var connection = DBConnUtil.GetConnection())
    {
        connection.Open();
        var command = new SqlCommand("SELECT * FROM Vehicle WHERE vehicleID = @vehicleID", connection);
        command.Parameters.AddWithValue("@vehicleID", vehicleId);

        using (var reader = command.ExecuteReader())
        {
            if (reader.Read())
            {
                return new Vehicle
                {
                    VehicleID = reader.GetInt32(reader.GetOrdinal("vehicleID")),
                    Make = reader.GetString(reader.GetOrdinal("make")),
                    Model = reader.GetString(reader.GetOrdinal("model")),
                    Year = reader.GetInt32(reader.GetOrdinal("year")),
                    DailyRate = Convert.ToDouble(reader["dailyRate"]),
                    Status = reader.GetString(reader.GetOrdinal("status")),
                    PassengerCapacity = reader.GetInt32(reader.GetOrdinal("passengerCapacity")),
                    EngineCapacity = Convert.ToSingle(reader["engineCapacity"])
                };
            }
            else
            {
                throw new CarNotFoundException($"Vehicle with ID {vehicleId} not found.");
            }
        }
    }
}


        public void UpdateVehicle(Vehicle vehicle)
        {
            // Code to update a vehicle
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Vehicle SET make = @make, model = @model, year = @year, status = @status, dailyRate = @dailyRate, passengerCapacity = @passengerCapacity, engineCapacity = @engineCapacity WHERE vehicleID = @vehicleID", connection);
                command.Parameters.AddWithValue("@make", vehicle.Make);
                command.Parameters.AddWithValue("@model", vehicle.Model);
                command.Parameters.AddWithValue("@year", vehicle.Year);
                command.Parameters.AddWithValue("@status", vehicle.Status);
                command.Parameters.AddWithValue("@dailyRate", vehicle.DailyRate);
                command.Parameters.AddWithValue("@passengerCapacity", vehicle.PassengerCapacity);
                command.Parameters.AddWithValue("@engineCapacity", vehicle.EngineCapacity);
                command.Parameters.AddWithValue("@vehicleID", vehicle.VehicleID);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteVehicle(int vehicleId)
        {
            // Code to delete a vehicle
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Vehicle WHERE vehicleID = @vehicleID", connection);
                command.Parameters.AddWithValue("@vehicleID", vehicleId);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new CarNotFoundException($"Vehicle with ID {vehicleId} not found.");
                }
            }
        }

        public void AddCustomer(Customer customer)
        {
            // Code to add a customer
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Customer (firstName, lastName, email, phoneNumber) VALUES (@firstName, @lastName, @email, @phoneNumber)", connection);
                command.Parameters.AddWithValue("@firstName", customer.FirstName);
                command.Parameters.AddWithValue("@lastName", customer.LastName);
                command.Parameters.AddWithValue("@email", customer.Email);
                command.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                command.ExecuteNonQuery();
            }
        }

        public Customer GetCustomerById(int customerId)
        {
            // Code to get a customer by ID
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Customer WHERE customerID = @customerID", connection);
                command.Parameters.AddWithValue("@customerID", customerId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Customer
                        {
                            CustomerID = reader.GetInt32(0),
                            FirstName = reader.GetString(1),
                            LastName = reader.GetString(2),
                            Email = reader.GetString(3),
                            PhoneNumber = reader.GetString(4)
                        };
                    }
                    else
                    {
                        throw new CustomerNotFoundException($"Customer with ID {customerId} not found.");
                    }
                }
            }
        }

        public void UpdateCustomer(Customer customer)
        {
            // Code to update a customer
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Customer SET firstName = @firstName, lastName = @lastName, email = @email, phoneNumber = @phoneNumber WHERE customerID = @customerID", connection);
                command.Parameters.AddWithValue("@firstName", customer.FirstName);
                command.Parameters.AddWithValue("@lastName", customer.LastName);
                command.Parameters.AddWithValue("@email", customer.Email);
                command.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                command.Parameters.AddWithValue("@customerID", customer.CustomerID);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            // Code to delete a customer
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Customer WHERE customerID = @customerID", connection);
                command.Parameters.AddWithValue("@customerID", customerId);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new CustomerNotFoundException($"Customer with ID {customerId} not found.");
                }
            }
        }


        // Implementation of methods from ICarLeaseRepository interface
        public void AddLease(Lease lease)
        {
            // Code to add a lease
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Lease (vehicleID, customerID, startDate, endDate, type) VALUES (@vehicleID, @customerID, @startDate, @endDate, @type)", connection);
                command.Parameters.AddWithValue("@vehicleID", lease.VehicleID);
                command.Parameters.AddWithValue("@customerID", lease.CustomerID);
                command.Parameters.AddWithValue("@startDate", lease.StartDate);
                command.Parameters.AddWithValue("@endDate", lease.EndDate);
                command.Parameters.AddWithValue("@type", lease.Type);
                command.ExecuteNonQuery();
            }
        }

        public Lease GetLeaseById(int leaseId)
        {
            // Code to get a lease by ID
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Lease WHERE leaseID = @leaseID", connection);
                command.Parameters.AddWithValue("@leaseID", leaseId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Lease
                        {
                            LeaseID = reader.GetInt32(0),
                            VehicleID = reader.GetInt32(1),
                            CustomerID = reader.GetInt32(2),
                            StartDate = reader.GetDateTime(3),
                            EndDate = reader.GetDateTime(4),
                            Type = reader.GetString(5)
                        };
                    }
                    else
                    {
                        throw new LeaseNotFoundException($"Lease with ID {leaseId} not found.");
                    }
                }
            }
        }

        public void UpdateLease(Lease lease)
        {
            // Code to update a lease
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("UPDATE Lease SET vehicleID = @vehicleID, customerID = @customerID, startDate = @startDate, endDate = @endDate, type = @type WHERE leaseID = @leaseID", connection);
                command.Parameters.AddWithValue("@vehicleID", lease.VehicleID);
                command.Parameters.AddWithValue("@customerID", lease.CustomerID);
                command.Parameters.AddWithValue("@startDate", lease.StartDate);
                command.Parameters.AddWithValue("@endDate", lease.EndDate);
                command.Parameters.AddWithValue("@type", lease.Type);
                command.Parameters.AddWithValue("@leaseID", lease.LeaseID);
                command.ExecuteNonQuery();
            }
        }

        public void DeleteLease(int leaseId)
        {
            // Code to delete a lease
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("DELETE FROM Lease WHERE leaseID = @leaseID", connection);
                command.Parameters.AddWithValue("@leaseID", leaseId);
                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected == 0)
                {
                    throw new LeaseNotFoundException($"Lease with ID {leaseId} not found.");
                }
            }
        }

        public void AddPayment(Payment payment)
        {
            // Code to add a payment
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("INSERT INTO Payment (leaseID, paymentDate, amount) VALUES (@leaseID, @paymentDate, @amount)", connection);
                command.Parameters.AddWithValue("@leaseID", payment.LeaseID);
                command.Parameters.AddWithValue("@paymentDate", payment.PaymentDate);
                command.Parameters.AddWithValue("@amount", payment.Amount);
                command.ExecuteNonQuery();
            }
        }

        public Payment GetPaymentById(int paymentId)
        {
            // Code to get a payment by ID
            using (var connection = DBConnUtil.GetConnection())
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Payment WHERE paymentID = @paymentID", connection);
                command.Parameters.AddWithValue("@paymentID", paymentId);
                using (var reader = command.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return new Payment
                        {
                            PaymentID = reader.GetInt32(0),
                            LeaseID = reader.GetInt32(1),
                            PaymentDate = reader.GetDateTime(2),
                            Amount = reader.GetDouble(3)
                        };
                    }
                    else
                    {
                        throw new LeaseNotFoundException($"Payment with ID {paymentId} not found.");
                    }
                }
            }
        }
    }
}