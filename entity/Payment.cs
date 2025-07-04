using System;
namespace CarRentalSystem.entity
{
    public class Payment
    {
        public int PaymentID { get; set; }
        public int LeaseID { get; set; }
        public DateTime PaymentDate { get; set; }
        public double Amount { get; set; }

        // Default constructor
        public Payment() { }

        // Parameterized constructor
        public Payment(int paymentID, int leaseID, DateTime paymentDate, double amount)
        {
            PaymentID = paymentID;
            LeaseID = leaseID;
            PaymentDate = paymentDate;
            Amount = amount;
        }
        public override string ToString()
        {
            return $"Payment ID: {PaymentID}, Lease ID: {LeaseID}, Payment Date: {PaymentDate.ToShortDateString()}, Amount: {Amount}";
        }
    }
}