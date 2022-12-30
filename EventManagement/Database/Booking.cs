using MessagePack;
using System.ComponentModel.DataAnnotations.Schema;

namespace EventManagement.Database
{
    public class Booking
    {
        public int bookingId  { get; set; }
        public string? cnic { get; set; } = string.Empty;
        public int eventID { get; set; }
        public int userID { get; set; }
        public Event? Event { get; set; }
        public User? User { get; set; }
        public DateTime? createdDate { get; set; }
    }
}
