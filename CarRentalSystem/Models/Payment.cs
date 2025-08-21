using System;

namespace CarRentalSystem.Models.Entity
{
    public class Payment
    {
        // Private fields
        private int paymentID;
        private int leaseID;
        private DateTime paymentDate;
        private decimal amount;

        // Default constructor
        public Payment() { }

        // Parameterized constructor
        public Payment(int paymentID, int leaseID, DateTime paymentDate, decimal amount)
        {
            this.paymentID = paymentID;
            this.leaseID = leaseID;
            this.paymentDate = paymentDate;
            this.amount = amount;
        }

        // Properties
        public int PaymentID { get => paymentID; set => paymentID = value; }
        public int LeaseID { get => leaseID; set => leaseID = value; }
        public DateTime PaymentDate { get => paymentDate; set => paymentDate = value; }
        public decimal Amount { get => amount; set => amount = value; }
    }
}
