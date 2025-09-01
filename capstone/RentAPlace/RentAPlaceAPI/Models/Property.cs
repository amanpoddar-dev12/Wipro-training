namespace RentAPlaceAPI.Models
{
    public class Property
    {
        public int PropertyId { get; set; }
        public int OwnerId { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Type { get; set; } = string.Empty;
        public string Location { get; set; } = string.Empty;
        public string? Features { get; set; }
        public decimal PricePerNight { get; set; }
        public double Rating { get; set; } = 0;
        public string? Images { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User? Owner { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
        public ICollection<Message>? Messages { get; set; }
    }
}
