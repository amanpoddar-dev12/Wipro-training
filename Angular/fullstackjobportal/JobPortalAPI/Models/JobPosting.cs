namespace JobPortalAPI.Models
{
    public class JobPosting
    {
        public int Id { get; set; }
        public string Title { get; set; } = "";
        public string Description { get; set; } = "";
        public string Company { get; set; } = "";
        public DateTime PostedOn { get; set; } = DateTime.Now;
    }
}
