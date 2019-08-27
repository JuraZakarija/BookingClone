using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingClone.DB;
using BookingClone.Dto;
using BookingClone.Models;
using BookingClone.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Jos komentara
namespace BookingClone.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {
        private readonly BookingCloneContext _context;
        private readonly IBookingService BookingService;

        public BookingsController(
            BookingCloneContext context,
            IBookingService bookingService
        )
        {
            _context = context;
            BookingService = bookingService;
        }

        // GET: api/bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingItems(
            [FromQuery] int? userId
        )
        {

            var bookings = _context.Bookings.AsQueryable();

            if(userId != null) {
                bookings = bookings.Where(b => b.UserId == userId);
            }

            return Ok(await bookings.ToListAsync());
        }

        // GET api/bookings/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Booking>> GetBookingItem(int id)
        {
            var bookingItem = await _context.Bookings.FindAsync(id);

            if (bookingItem == null)
            {
                return NotFound();
            }
            return bookingItem;
        }

        [HttpPost]
        [Route("is_available")]
        public bool CheckAvailability([FromBody] AvailabilityRequest request)
        {
            return this.BookingService.IsAvailable(request.CheckIn, request.CheckOut, request.RoomId);
        }

        // POST api/bookings
        [HttpPost]
        public async Task<ActionResult<Booking>> PostBookingItem(Booking item)
        {
            if(item.CheckIn > item.CheckOut)
            {
                return BadRequest("Datum prijave ne može biti veći od dana odjave");
            }
            _context.Bookings.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetBookingItem), new { id = item.Id }, item);
        }

        // PUT api/bookings/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBookingItem(int id, [FromBody] Booking item)
        {
            item.Id = id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/bookings/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBookingItem(int id)
        {
            var bookingItem = await _context.Bookings.FindAsync(id);

            if (bookingItem == null)
            {
                return NotFound();
            }

            _context.Bookings.Remove(bookingItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
