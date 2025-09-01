namespace RentAPlaceAPI.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }
        public int PropertyId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Status { get; set; } = "Pending"; // Pending/Confirmed/Cancelled

        // Navigation
        public User? User { get; set; }
        public Property? Property { get; set; }
    }
}
