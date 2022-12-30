namespace EventManagement.Database
{
    public class User
    {
        public int userId { get; set; }
        public string userName { get; set; } = string.Empty;
        public string password { get; set; } = string.Empty;
        public bool isAdmin { get; set; }
        public List<Booking>? bookings{ get; set; }

    }
}
