using System;
using CarRentalSystem.entity;

namespace CarRentalSystem.dao
{
    public interface ICarLeaseRepository
    {
        // Vehicle methods
        void AddVehicle(Vehicle vehicle);
        Vehicle GetVehicleById(int vehicleId);
        void UpdateVehicle(Vehicle vehicle);
        void DeleteVehicle(int vehicleId);

        // Customer methods
        void AddCustomer(Customer customer);
        Customer GetCustomerById(int customerId);
        void UpdateCustomer(Customer customer);
        void DeleteCustomer(int customerId);

        // Lease methods
        void AddLease(Lease lease);
        Lease GetLeaseById(int leaseId);
        void UpdateLease(Lease lease);
        void DeleteLease(int leaseId);

        // Payment methods
        void AddPayment(Payment payment);
        Payment GetPaymentById(int paymentId);
    }
}
