namespace EventManagement.Database
{
    public class Event
    {
        public int eventId { get; set; }
        public string eventName { get; set; } = string.Empty;
        public string? eventDescription { get; set; } = string.Empty;
        public string? venue { get; set; } = string.Empty;
        public string? organizationName { get; set; } = string.Empty;
        public string? organzationDescription { get; set; } = string.Empty;
        public string? categoryName { get; set; } = string.Empty;
        public int? price { get; set; }
        public DateTime? startTime { get; set; }
        public DateTime? endTime { get; set; }
        public DateTime? registrationEndTime { get; set; }
        public List<Booking>? bookings { get; set; }

    }
}
