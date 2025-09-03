namespace RentAPlaceAPI.Models
{
    public class Message
    {
        public int MessageId { get; set; }
        public int FromUserId { get; set; }
        public int ToUserId { get; set; }
        public int PropertyId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime SentAt { get; set; } = DateTime.Now;

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public User? FromUser { get; set; }
        public User? ToUser { get; set; }
        public Property? Property { get; set; }
    }
}
