using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingClone.DB;
using BookingClone.Dto;
using BookingClone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.Controllers
{
    [Route("api/guests")]
    [ApiController]
    public class GuestsController : ControllerBase
    {
        private readonly BookingCloneContext _context;

        public GuestsController(BookingCloneContext context)
        {
            _context = context;
        }

        // GET: api/guests
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Guest>>> GetGuestItems()
        {
            var items = await _context.Guests.AsQueryable().Select(g =>
                new GuestDto {
                    Id = g.Id,
                    FullName = g.FirstName + " " + g.LastName,
                    Email = g.Email,
                    Birthdate = g.Birthdate.ToString(),
                    BookingCount = g.Bookings.Count,
                    Gender = g.Gender,
                    PhoneNumber = g.PhoneNumber,
                }
            ).ToListAsync();

            return Ok(items);
        }


        // GET api/guests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<GuestDto>> GetGuestItem(int id)
        {
            var g = await _context.Guests.FindAsync(id);

            if (g == null) { return NotFound(); }

            var guestDto = new GuestDto {
                
                Birthdate = String.Format("{0:yyyy-MM-dd}", g.Birthdate),
                Id = g.Id,
                FirstName = g.FirstName,
                LastName = g.LastName,
                Email = g.Email,
                Gender = g.Gender,
                PhoneNumber = g.PhoneNumber,

            };
            return guestDto;
        }

        // POST api/guest
        [HttpPost]
        public async Task<ActionResult<Guest>> PostGuestItem(Guest item)
        {
            _context.Guests.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGuestItem), new { id = item.Id }, item);
        }

        // PUT api/guests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuestItem(int id, [FromBody] Guest item)
        {
            item.Id = id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/guests/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteGuestItem(int id)
        {
            var guestItem = await _context.Guests.FindAsync(id);

            if (guestItem == null)
            {
                return NotFound();
            }

            _context.Guests.Remove(guestItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
