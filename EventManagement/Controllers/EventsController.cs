using EventManagement.Database;
using Microsoft.AspNetCore.Connections;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace EventManagement.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        public List<Event> bookedEvents = new List<Event>();
        public List<Event> unbookedEvents = new List<Event>();

        private readonly DatabaseContext _context;

        public EventsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: api/Events
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Event>>> Getevents()
        {
            return await _context.events.ToListAsync();
        }

        // GET: api/Events/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Event>> GetEvent(int id)
        {
            var @event = await _context.events.FindAsync(id);

            if (@event == null)
            {
                return NotFound();
            }

            return @event;
        }

        [HttpGet("getbookedevents/{id}")]
        public async Task<ActionResult<IEnumerable<Event>>> GetBookedEvent(int id)
        {
            var bookings = await _context
                .bookings
                .Where(s => s.userID == id)
                .Include(s => s.Event)
                .ToListAsync();
            foreach (var booking in bookings)
            {
                if (booking.Event != null)
                    bookedEvents.Add(booking.Event);
            }
            return bookedEvents;
        }

        [HttpGet("getunbookedevents/{id}")]
        public async Task<ActionResult<List<Event>>> GetUnBookedEvent(int id)
        {

            var bookings = await _context
                .bookings
                .Where(s => s.userID == id)
                .ToListAsync();
            List<int> ids = new List<int>();
            foreach(var booking in bookings)
            {
                ids.Add(booking.eventID);
            }
            var events = await _context
                .events.ToListAsync();
            foreach (var x in events)
            {
                if (ids.Contains(x.eventId)) 
                {
                    continue;
                }
                unbookedEvents.Add(x);
            }
            return unbookedEvents;
        }

        [HttpGet("search/{name}")]
        public async Task<ActionResult<Event>> PostStringToSearch(string name)
        {
            var result =await  _context
                .events
                .Where(s => s.eventName == name)
                .FirstOrDefaultAsync();
            if (result != null)
                return result;
            else return NotFound();
        }
        [HttpGet("getbyname/{toSearch}")]
        public IQueryable GetEventbyName(string toSearch)
        {
            var events = from e in _context.events select e;

            if (!String.IsNullOrEmpty(toSearch))
            {
                events = events.Where(s => s.eventName!.Contains(toSearch) || s.organizationName!.Contains(toSearch) || s.categoryName!.Contains(toSearch) ||
                    s.venue!.Contains(toSearch) || s.eventDescription!.Contains(toSearch));
            }
#pragma warning disable CS8603 // Possible null reference return.
            return events;
#pragma warning restore CS8603 // Possible null reference return.
        }

        // PUT: api/Events/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEvent(int id, Event @event)
        {
            if (id != @event.eventId)
            {
                return BadRequest();
            }

            _context.Entry(@event).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventExists(id))
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

        // POST: api/Events
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Event>> PostEvent(Event @event)
        {
            @event.startTime = DateTime.Now;
            if ((@event.endTime == null) || (@event.endTime < @event.startTime) || (@event.endTime < @event.registrationEndTime))
            {
                return BadRequest();
            }
            _context.events.Add(@event);
            await _context.SaveChangesAsync();
            return @event;
        }

        // DELETE: api/Events/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEvent(int id)
        {
            var @event = await _context.events.FindAsync(id);
            if (@event == null)
            {
                return NotFound();
            }

            _context.events.Remove(@event);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EventExists(int id)
        {
            return _context.events.Any(e => e.eventId == id);
        }
    }
}
