using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgerBar.Data;
using BurgerBar.Entities;
using Microsoft.AspNetCore.Authorization;

namespace BurgerBar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypesController : ControllerBase
    {
        private readonly BurgerBarContext _context;

        public PaymentTypesController(BurgerBarContext context)
        {
            _context = context;
        }

        // GET: api/PaymentTypes
        [HttpGet]
        public IEnumerable<PaymentType> GetPaymentType()
        {
            return _context.PaymentType;
        }

        // GET: api/PaymentTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPaymentType([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentType = await _context.PaymentType.FindAsync(id);

            if (paymentType == null)
            {
                return NotFound();
            }

            return Ok(paymentType);
        }

        // PUT: api/PaymentTypes/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutPaymentType([FromRoute] long id, [FromBody] PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paymentType.Id)
            {
                return BadRequest();
            }

            _context.Entry(paymentType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PaymentTypeExists(id))
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

        // POST: api/PaymentTypes
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostPaymentType([FromBody] PaymentType paymentType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.PaymentType.Add(paymentType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPaymentType", new { id = paymentType.Id }, paymentType);
        }

        // DELETE: api/PaymentTypes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeletePaymentType([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var paymentType = await _context.PaymentType.FindAsync(id);
            if (paymentType == null)
            {
                return NotFound();
            }

            _context.PaymentType.Remove(paymentType);
            await _context.SaveChangesAsync();

            return Ok(paymentType);
        }

        private bool PaymentTypeExists(long id)
        {
            return _context.PaymentType.Any(e => e.Id == id);
        }
    }
}