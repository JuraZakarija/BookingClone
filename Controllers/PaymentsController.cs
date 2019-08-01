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
    [Route("api/payments")]
    [ApiController]
    public class PaymentsController : ControllerBase
    {
        private readonly BookingCloneContext _context;

        public PaymentsController(BookingCloneContext context)
        {
            _context = context;
        }

        // GET: api/payments
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Payment>>> GetPaymentItems()
        {
            var items = await _context.Payments.ToListAsync();

            return Ok(items);
        }

        // GET api/payments/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Payment>> GetPaymentItem(int id)
        {
            var paymentItem = await _context.Payments.FindAsync(id);

            if (paymentItem == null)
            {
                return NotFound();
            }
            return paymentItem;
        }

        // POST api/payments
        [HttpPost]
        public async Task<ActionResult<Payment>> PostPaymentItem(Payment item)
        {
            _context.Payments.Add(item);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetPaymentItem), new { id = item.Id }, item);
        }

        // PUT api/payment/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPaymentItem(int id, [FromBody] Payment item)
        {
            item.Id = id;

            _context.Entry(item).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        // DELETE api/payment/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePaymentItem(int id)
        {
            var paymentItem = await _context.Payments.FindAsync(id);

            if (paymentItem == null)
            {
                return NotFound();
            }

            _context.Payments.Remove(paymentItem);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
