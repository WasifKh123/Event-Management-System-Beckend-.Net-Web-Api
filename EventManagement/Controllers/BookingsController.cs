using EventManagement.Database;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly DatabaseContext _context;

        public BookingsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> Getbookings()
        {
            return await _context.bookings.ToListAsync();
        }

        // GET: api/Bookings/5
        [HttpGet("{userId}/{eventId}")]
        public async Task<ActionResult<Booking>> GetBooking(int userId,int eventId)
        {
            Console.WriteLine("mamo",eventId,userId);
            var booking = await _context.bookings
                .Where(s => s.userID == userId & s.eventID == eventId)
                .ToListAsync();
            
            if (booking == null)
            {
                return NotFound();
            }
            return booking[0];
        }

        // PUT: api/Bookings/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBooking(int id, Booking booking)
        {
            if (id != booking.userID)
            {
                return BadRequest();
            }

            _context.Entry(booking).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookingExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/Bookings
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost("add/{userId}/{eventId}")]
        public async Task<ActionResult<Booking>> PostBooking(int userId , int eventId)
        {
            Booking booking= new Booking();
            booking.eventID = eventId;
            booking.userID = userId;
            booking.createdDate = DateTime.Now;
            Console.WriteLine("jackoooooooooooooo skdkjkasdk skdjak");
            Console.WriteLine("");
            _context.bookings.Add(booking);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (BookingExists(booking.userID))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }
            var retro = await _context.bookings.Where(s => s.eventID == eventId && s.userID == userId).FirstOrDefaultAsync();
            if (retro != null)
                return retro;
            else
                return Conflict();
        }

        // DELETE: api/Bookings/5
        [HttpDelete("{userId}/{eventId}")]
        public async Task<IActionResult> DeleteBooking(int userId,int eventId)
        {
            var booking = await _context.bookings
                .Where(s=>s.userID==userId & s.eventID == eventId)
                .ToListAsync();
            if (booking == null)
            {
                return NotFound();
            }

            _context.bookings.Remove(booking[0]);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool BookingExists(int id)
        {
            return _context.bookings.Any(e => e.userID == id);
        }
    }
}
