using EventManagement.Database;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Database
{
    public class DatabaseContext : DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder) 
        {
            modelBuilder.Entity<Booking>()
                .HasOne(b => b.Event)
                .WithMany(ba => ba.bookings)
                .HasForeignKey(bi => bi.eventID);

            modelBuilder.Entity<Booking>()
                .HasOne(b => b.User)
                .WithMany(ba => ba.bookings)
                .HasForeignKey(bi => bi.userID);

            modelBuilder.Entity<Booking>()
                .HasAlternateKey(s => new { s.userID, s.eventID });

        }
        public DbSet<Event> events { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Booking> bookings { get; set; }   


    }
}
