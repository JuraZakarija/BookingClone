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
    [Route("api/agencies")]
    [ApiController]
    public class AgenciesController : ControllerBase
    {
        private readonly BookingCloneContext _context;

        public AgenciesController(BookingCloneContext context)
        {
            _context = context;
        }

        // GET: api/agencies
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Agency>>> GetAgencyItems()
        {
            var items = await _context.Agencies.ToListAsync();

            return Ok(items);
        }

        // GET api/agencys/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Agency>> GetAgencyItem(int id)
        {
            var agencyItem = await _context.Agencies.FindAsync(id);

            if (agencyItem == null)
            {
                return NotFound();
            }
            return agencyItem;
        }

        // POST api/agencys
        [HttpPost]
        public async Task<ActionResult<Agency>> PostAgencyItem(Agency item)
        {
            _context.Agencies.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetAgencyItem), new { id = item.Id }, item);
        }

        // PUT api/agencies/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutAgencyItem(int id, [FromBody] Agency item)
        {
            item.Id = id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/agency/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAgencyItem(int id)
        {
            var agencyItem = await _context.Agencies.FindAsync(id);

            if (agencyItem == null)
            {
                return NotFound();
            }

            _context.Agencies.Remove(agencyItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
