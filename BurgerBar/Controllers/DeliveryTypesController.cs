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
    public class DeliveryTypesController : ControllerBase
    {
        private readonly BurgerBarContext _context;

        public DeliveryTypesController(BurgerBarContext context)
        {
            _context = context;
        }

        // GET: api/DeliveryTypes
        [HttpGet]
        public IEnumerable<DeliveryType> GetDeliveryType()
        {
            return _context.DeliveryType;
        }

        // GET: api/DeliveryTypes/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDeliveryType([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deliveryType = await _context.DeliveryType.FindAsync(id);

            if (deliveryType == null)
            {
                return NotFound();
            }

            return Ok(deliveryType);
        }

        // PUT: api/DeliveryTypes/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutDeliveryType([FromRoute] long id, [FromBody] DeliveryType deliveryType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != deliveryType.Id)
            {
                return BadRequest();
            }

            _context.Entry(deliveryType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeliveryTypeExists(id))
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

        // POST: api/DeliveryTypes
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostDeliveryType([FromBody] DeliveryType deliveryType)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.DeliveryType.Add(deliveryType);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDeliveryType", new { id = deliveryType.Id }, deliveryType);
        }

        // DELETE: api/DeliveryTypes/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteDeliveryType([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var deliveryType = await _context.DeliveryType.FindAsync(id);
            if (deliveryType == null)
            {
                return NotFound();
            }

            _context.DeliveryType.Remove(deliveryType);
            await _context.SaveChangesAsync();

            return Ok(deliveryType);
        }

        private bool DeliveryTypeExists(long id)
        {
            return _context.DeliveryType.Any(e => e.Id == id);
        }
    }
}