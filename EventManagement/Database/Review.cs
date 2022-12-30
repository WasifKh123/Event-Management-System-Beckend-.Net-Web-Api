namespace EventManagement.Database
{
    public class Review
    {
        public int reviewId { get; set; }
        public string review { get; set; } = string.Empty;
        public DateTime createdTime { get; set; }
        public string personName { get; set; } = string.Empty;
        public int? eventId { get; set; }
        public Event events { get; set; }
        
    }
}
