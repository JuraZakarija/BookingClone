using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingClone.DB;
using BookingClone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

// Jos komentara
namespace BookingClone.Controllers
{
    [Route("api/bookings")]
    [ApiController]
    public class BookingsController : ControllerBase
    {private readonly BookingCloneContext _context;

        public BookingsController(BookingCloneContext context)
        {
            _context = context;
        }
            /* 
            if (_context.Bookings.Count() < 2)
            {
                // Agencys constructor
                _context.Agencies.Add(new Agency { Name = "Todoric" });
                _context.Agencies.Add(new Agency { Name = "Deset" });
                _context.SaveChanges();

                // Hotels construktor
                _context.Hotels.Add(new Hotel { Name = "Hotel Kašteli" });
                _context.Hotels.Add(new Hotel { Name = "Esplanada" });
                _context.SaveChanges();

                // Payments constructor
                _context.Payments.Add(new Payment { Price = 345.34m });
                _context.Payments.Add(new Payment { Price = 23.54m });
                _context.SaveChanges();

                // Rooms constructor
                _context.Rooms.Add(new Room { HotelId = 1, Size = 50, NumberOfBeds = 4, Type = "Apartman"});
                _context.Rooms.Add(new Room { HotelId = 2, Size =40 , NumberOfBeds = 4, Type = "Apartman"});
                _context.SaveChanges();

                // Gusets constructor
                _context.Guests.Add(new Guest { FirstName = "Rade", PaymentId = 1 });
                _context.Guests.Add(new Guest { FirstName = "Izet", PaymentId = 2 });  
                _context.SaveChanges();            
                
                // Bookings constructor
                _context.Bookings.Add(new Booking { Price = 250.6m, AgencyId = 1, GuestId = 1, RoomId = 1, 
                                                    HotelId = 1, PaymentId = 1 });
                _context.Bookings.Add(new Booking { Price = 320.0m, AgencyId = 2, GuestId = 2, RoomId = 2, 
                                                    HotelId = 2, PaymentId = 2 });
                
                _context.SaveChanges();
                */

        // GET: api/bookings
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Booking>>> GetBookingItems()
        {
            var items = await _context.Bookings.ToListAsync();

            return Ok(items);
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
