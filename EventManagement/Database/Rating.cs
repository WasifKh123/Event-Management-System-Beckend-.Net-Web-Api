namespace EventManagement.Database
{
    public class Rating
    {
        public int ratingId { get; set; }
        public int rating { get; set; }
        public DateTime createdTime { get; set; }
        public string personName { get; set; } = string.Empty;
        public string eventName { get; set; } = string.Empty;
    }
}
