using CarRentalSystem.Models.Entity;
using CarRentalSystem.Exceptions;
using CarRentalSystem.Utils;
using System;
using System.Collections.Generic;

using Microsoft.Data.SqlClient;
namespace CarRentalSystem.DAO
{
    public class CarLeaseRepositoryImpl : ICarLeaseRepository
    {
        private readonly SqlConnection connection;

        public CarLeaseRepositoryImpl()
        {
            connection = DBConnection.GetConnection(); // Utils class
        }

        // ================= CAR MANAGEMENT =================
        public void AddCar(Car car)
        {
            string query = "INSERT INTO Vehicle (Make, Model, Year, DailyRate, Status, PassengerCapacity, EngineCapacity) " +
                           "VALUES (@Make, @Model, @Year, @DailyRate, @Status, @PassengerCapacity, @EngineCapacity)";
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@Make", car.Make);
            cmd.Parameters.AddWithValue("@Model", car.Model);
            cmd.Parameters.AddWithValue("@Year", car.Year);
            cmd.Parameters.AddWithValue("@DailyRate", car.DailyRate);
            cmd.Parameters.AddWithValue("@Status", car.Status);
            cmd.Parameters.AddWithValue("@PassengerCapacity", car.PassengerCapacity);
            cmd.Parameters.AddWithValue("@EngineCapacity", car.EngineCapacity);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void RemoveCar(int carID)
        {
            string query = "DELETE FROM Vehicle WHERE VehicleID=@VehicleID";
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@VehicleID", carID);

            connection.Open();
            int rows = cmd.ExecuteNonQuery();
            connection.Close();

            if (rows == 0)
                throw new CarNotFoundException($"Car with ID {carID} not found.");
        }

        public List<Car> ListAvailableCars()
        {
            List<Car> cars = new List<Car>();
            string query = "SELECT * FROM Vehicle WHERE Status='available'";
            using SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cars.Add(new Car(
                    (int)reader["VehicleID"],
                    reader["Make"].ToString(),
                    reader["Model"].ToString(),
                    (int)reader["Year"],
                    (decimal)reader["DailyRate"],
                    reader["Status"].ToString(),
                    (int)reader["PassengerCapacity"],
                    reader["EngineCapacity"].ToString()
                ));
            }
            connection.Close();
            return cars;
        }

        public List<Car> ListRentedCars()
        {
            List<Car> cars = new List<Car>();
            string query = "SELECT * FROM Vehicle WHERE Status='notAvailable'";
            using SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                cars.Add(new Car(
                    (int)reader["VehicleID"],
                    reader["Make"].ToString(),
                    reader["Model"].ToString(),
                    (int)reader["Year"],
                    (decimal)reader["DailyRate"],
                    reader["Status"].ToString(),
                    (int)reader["PassengerCapacity"],
                    reader["EngineCapacity"].ToString()
                ));
            }
            connection.Close();
            return cars;
        }

        public Car FindCarById(int carID)
        {
            string query = "SELECT * FROM Vehicle WHERE VehicleID=@VehicleID";
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@VehicleID", carID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Car car = new Car(
                    (int)reader["VehicleID"],
                    reader["Make"].ToString(),
                    reader["Model"].ToString(),
                    (int)reader["Year"],
                    (decimal)reader["DailyRate"],
                    reader["Status"].ToString(),
                    (int)reader["PassengerCapacity"],
                    reader["EngineCapacity"].ToString()
                );
                connection.Close();
                return car;
            }
            connection.Close();
            throw new CarNotFoundException($"Car with ID {carID} not found.");
        }

        // ================= CUSTOMER MANAGEMENT =================
        public void AddCustomer(Customer customer)
        {
            string query = "INSERT INTO Customer (FirstName, LastName, Email, PhoneNumber) VALUES (@FirstName, @LastName, @Email, @PhoneNumber)";
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@FirstName", customer.FirstName);
            cmd.Parameters.AddWithValue("@LastName", customer.LastName);
            cmd.Parameters.AddWithValue("@Email", customer.Email);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public void RemoveCustomer(int customerID)
        {
            string query = "DELETE FROM Customer WHERE CustomerID=@CustomerID";
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CustomerID", customerID);

            connection.Open();
            int rows = cmd.ExecuteNonQuery();
            connection.Close();

            if (rows == 0)
                throw new CustomerNotFoundException($"Customer with ID {customerID} not found.");
        }

        public List<Customer> ListCustomers()
        {
            List<Customer> customers = new List<Customer>();
            string query = "SELECT * FROM Customer";
            using SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                customers.Add(new Customer(
                    (int)reader["CustomerID"],
                    reader["FirstName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["Email"].ToString(),
                    reader["PhoneNumber"].ToString()
                ));
            }
            connection.Close();
            return customers;
        }

        public Customer FindCustomerById(int customerID)
        {
            string query = "SELECT * FROM Customer WHERE CustomerID=@CustomerID";
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CustomerID", customerID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Customer customer = new Customer(
                    (int)reader["CustomerID"],
                    reader["FirstName"].ToString(),
                    reader["LastName"].ToString(),
                    reader["Email"].ToString(),
                    reader["PhoneNumber"].ToString()
                );
                connection.Close();
                return customer;
            }
            connection.Close();
            throw new CustomerNotFoundException($"Customer with ID {customerID} not found.");
        }

        // ================= LEASE MANAGEMENT =================
        public Lease CreateLease(int customerID, int carID, DateTime startDate, DateTime endDate, string type)
        {
            string query = "INSERT INTO Lease (VehicleID, CustomerID, StartDate, EndDate, Type) OUTPUT INSERTED.LeaseID VALUES (@VehicleID, @CustomerID, @StartDate, @EndDate, @Type)";
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@VehicleID", carID);
            cmd.Parameters.AddWithValue("@CustomerID", customerID);
            cmd.Parameters.AddWithValue("@StartDate", startDate);
            cmd.Parameters.AddWithValue("@EndDate", endDate);
            cmd.Parameters.AddWithValue("@Type", type);

            connection.Open();
            int leaseID = (int)cmd.ExecuteScalar();
            connection.Close();

            return new Lease(leaseID, carID, customerID, startDate, endDate, type);
        }

        public Lease ReturnCar(int leaseID)
        {
            string query = "SELECT * FROM Lease WHERE LeaseID=@LeaseID";
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LeaseID", leaseID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader.Read())
            {
                Lease lease = new Lease(
                    (int)reader["LeaseID"],
                    (int)reader["VehicleID"],
                    (int)reader["CustomerID"],
                    (DateTime)reader["StartDate"],
                    (DateTime)reader["EndDate"],
                    reader["Type"].ToString()
                );
                connection.Close();
                return lease;
            }
            connection.Close();
            throw new LeaseNotFoundException($"Lease with ID {leaseID} not found.");
        }

        public List<Lease> ListActiveLeases()
        {
            List<Lease> leases = new List<Lease>();
            string query = "SELECT * FROM Lease WHERE EndDate >= GETDATE()";
            using SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                leases.Add(new Lease(
                    (int)reader["LeaseID"],
                    (int)reader["VehicleID"],
                    (int)reader["CustomerID"],
                    (DateTime)reader["StartDate"],
                    (DateTime)reader["EndDate"],
                    reader["Type"].ToString()
                ));
            }
            connection.Close();
            return leases;
        }

        public List<Lease> ListLeaseHistory()
        {
            List<Lease> leases = new List<Lease>();
            string query = "SELECT * FROM Lease";
            using SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                leases.Add(new Lease(
                    (int)reader["LeaseID"],
                    (int)reader["VehicleID"],
                    (int)reader["CustomerID"],
                    (DateTime)reader["StartDate"],
                    (DateTime)reader["EndDate"],
                    reader["Type"].ToString()
                ));
            }
            connection.Close();
            return leases;
        }

        // ================= PAYMENT HANDLING =================
        public void RecordPayment(Lease lease, decimal amount)
        {
            string query = "INSERT INTO Payment (LeaseID, PaymentDate, Amount) VALUES (@LeaseID, GETDATE(), @Amount)";
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@LeaseID", lease.LeaseID);
            cmd.Parameters.AddWithValue("@Amount", amount);

            connection.Open();
            cmd.ExecuteNonQuery();
            connection.Close();
        }

        public List<Payment> GetPaymentHistory(int customerID)
        {
            List<Payment> payments = new List<Payment>();
            string query = "SELECT P.* FROM Payment P INNER JOIN Lease L ON P.LeaseID = L.LeaseID WHERE L.CustomerID=@CustomerID";
            using SqlCommand cmd = new SqlCommand(query, connection);
            cmd.Parameters.AddWithValue("@CustomerID", customerID);

            connection.Open();
            SqlDataReader reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                payments.Add(new Payment(
                    (int)reader["PaymentID"],
                    (int)reader["LeaseID"],
                    (DateTime)reader["PaymentDate"],
                    (decimal)reader["Amount"]
                ));
            }
            connection.Close();
            return payments;
        }

        public decimal GetTotalRevenue()
        {
            string query = "SELECT SUM(Amount) FROM Payment";
            using SqlCommand cmd = new SqlCommand(query, connection);

            connection.Open();
            object result = cmd.ExecuteScalar();
            connection.Close();

            return result == DBNull.Value ? 0 : Convert.ToDecimal(result);
        }
    }
}
