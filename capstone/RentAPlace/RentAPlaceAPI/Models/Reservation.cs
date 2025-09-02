namespace RentAPlaceAPI.Models
{
    public class Reservation
    {
        public int ReservationId { get; set; }
        public int UserId { get; set; }     // set from JWT
        public int PropertyId { get; set; }
        public DateTime CheckIn { get; set; }
        public DateTime CheckOut { get; set; }
        public string Status { get; set; } = "Pending";  // default
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User User { get; set; }
        public Property Property { get; set; }
    }
}
