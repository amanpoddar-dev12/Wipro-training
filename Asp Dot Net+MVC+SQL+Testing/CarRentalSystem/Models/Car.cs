namespace CarRentalSystem.Models.Entity
{
    public class Car
    {
        // Private fields
        private int vehicleID;
        private string make;
        private string model;
        private int year;
        private decimal dailyRate;
        private string status; // available, notAvailable
        private int passengerCapacity;
        private string engineCapacity;

        // Default constructor
        public Car() { }

        // Parameterized constructor
        public Car(int vehicleID, string make, string model, int year, decimal dailyRate, string status, int passengerCapacity, string engineCapacity)
        {
            this.vehicleID = vehicleID;
            this.make = make;
            this.model = model;
            this.year = year;
            this.dailyRate = dailyRate;
            this.status = status;
            this.passengerCapacity = passengerCapacity;
            this.engineCapacity = engineCapacity;
        }

        // Properties (getters and setters)
        public int VehicleID { get => vehicleID; set => vehicleID = value; }
        public string Make { get => make; set => make = value; }
        public string Model { get => model; set => model = value; }
        public int Year { get => year; set => year = value; }
        public decimal DailyRate { get => dailyRate; set => dailyRate = value; }
        public string Status { get => status; set => status = value; }
        public int PassengerCapacity { get => passengerCapacity; set => passengerCapacity = value; }
        public string EngineCapacity { get => engineCapacity; set => engineCapacity = value; }
    }
}
