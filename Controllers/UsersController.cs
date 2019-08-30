
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
    [Route("api/users")]
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
        public async Task<ActionResult<IEnumerable<AuthUser>>> GetGuestItems()
        {
            var items = await _context.Users.AsQueryable().Select(g =>
                new UserDto {
                    Id = g.Id,
                    FullName = g.FirstName + " " + g.LastName,
                    Email = g.Email,
                    Birthdate = g.Birthdate.ToString(),
                    BookingCount = g.Bookings.Count,
                    Gender = g.Gender,
                    PhoneNumber = g.PhoneNumber,
                    Role = g.Role
                    
                }
            ).ToListAsync();

            return Ok(items);
        }


        // GET api/guests/5
        [HttpGet("{id}")]
        public async Task<ActionResult<UserDto>> GetGuestItem(int id)
        {
            var g = await _context.Users.FindAsync(id);

            if (g == null) { return NotFound(); }

            var userDto = new UserDto {
                
                Birthdate = String.Format("{0:yyyy-MM-dd}", g.Birthdate),
                Id = g.Id,
                FirstName = g.FirstName,
                LastName = g.LastName,
                FullName = g.FirstName + " " + g.LastName,
                Email = g.Email,
                Gender = g.Gender,
                PhoneNumber = g.PhoneNumber,
                Password = g.PasswordHash,
                Role = g.Role
                    
            };
            return userDto;
        }

        // POST api/guest
        [HttpPost]
        public async Task<ActionResult<AuthUser>> PostGuestItem(AuthUser item)
        {
            _context.Users.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetGuestItem), new { id = item.Id }, item);
        }

        // PUT api/guests/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutGuestItem(int id, [FromBody] AuthUser item)
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
            var guestItem = await _context.Users.FindAsync(id);

            if (guestItem == null)
            {
                return NotFound();
            }

            _context.Remove(guestItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}