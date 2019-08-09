using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using BookingClone.DB;
using BookingClone.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingClone.Controllers
{
    [Route("api/rooms")]
    [ApiController]
    public class RoomsController : ControllerBase
    {
        private readonly BookingCloneContext _context;

        public RoomsController(BookingCloneContext context)
        {
            _context = context;
        }

        // GET: api/rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>>> GetRoomItems()
        {
            var items = await _context.Rooms.ToListAsync();

            return Ok(items);
        }

        // GET api/rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoomItem(int id)
        {
            var roomItem = await _context.Rooms.FindAsync(id);

            if (roomItem == null)
            {
                return NotFound();
            }
            return roomItem;
        }


        // POST api/room
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoomItem(Room item)
        {
            _context.Rooms.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetRoomItem), new { id = item.Id }, item);
        }

        // PUT api/rooms/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoomItem(int id, [FromBody] Room item)
        {
            item.Id = id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoomItem(int id)
        {
            var roomItem = await _context.Rooms.FindAsync(id);

            if (roomItem == null)
            {
                return NotFound();
            }

            _context.Rooms.Remove(roomItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
