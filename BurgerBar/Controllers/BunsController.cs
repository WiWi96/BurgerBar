using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgerBar.Data;
using BurgerBar.Model;

namespace BurgerBar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BunsController : ControllerBase
    {
        private readonly BurgerBarContext _context;

        public BunsController(BurgerBarContext context)
        {
            _context = context;
        }

        // GET: api/Buns
        [HttpGet]
        public IEnumerable<Bun> GetBun()
        {
            return _context.Bun;
        }

        // GET: api/Buns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBun([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bun = await _context.Bun.FindAsync(id);

            if (bun == null)
            {
                return NotFound();
            }

            return Ok(bun);
        }

        // PUT: api/Buns/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBun([FromRoute] long id, [FromBody] Bun bun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != bun.Id)
            {
                return BadRequest();
            }

            _context.Entry(bun).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BunExists(id))
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

        // POST: api/Buns
        [HttpPost]
        public async Task<IActionResult> PostBun([FromBody] Bun bun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Bun.Add(bun);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBun", new { id = bun.Id }, bun);
        }

        // DELETE: api/Buns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBun([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bun = await _context.Bun.FindAsync(id);
            if (bun == null)
            {
                return NotFound();
            }

            _context.Bun.Remove(bun);
            await _context.SaveChangesAsync();

            return Ok(bun);
        }

        private bool BunExists(long id)
        {
            return _context.Bun.Any(e => e.Id == id);
        }
    }
}