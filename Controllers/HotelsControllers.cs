using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BookingClone.DB;
using BookingClone.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.Controllers
{
    [Route("api/hotels")]
    [ApiController]
    public class HotelsController : ControllerBase
    {
        private readonly BookingCloneContext _context;

        public HotelsController(BookingCloneContext context)
        {
            _context = context;
        }

        // GET: api/hotels
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Hotel>>> GetHotelItems()
        {
            var items = await _context.Hotels.ToListAsync();

            return Ok(items);
        }

        // GET api/hotels/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Hotel>> GetHotelItem(int id)
        {
            var hotelItem = await _context.Hotels.FindAsync(id);

            if (hotelItem == null)
            {
                return NotFound();
            }
            return hotelItem;
        }

        // POST api/hotels
        [HttpPost]
        public async Task<ActionResult<Hotel>> PostHotelItem(Hotel item)
        {
            _context.Hotels.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetHotelItem), new { id = item.Id }, item);
        }

        // PUT api/hotels/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutHotelItem(int id, [FromBody] Hotel item)
        {
            item.Id = id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/hotel/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelItem(int id)
        {
            var hotelItem = await _context.Hotels.FindAsync(id);

            if (hotelItem == null)
            {
                return NotFound();
            }

            _context.Hotels.Remove(hotelItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
