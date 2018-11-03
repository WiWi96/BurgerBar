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
    public class BurgersController : ControllerBase
    {
        private readonly BurgerBarContext _context;

        public BurgersController(BurgerBarContext context)
        {
            _context = context;
        }

        // GET: api/Burgers
        [HttpGet]
        public IEnumerable<Burger> GetBurger()
        {
            return _context.Burger;
        }

        // GET: api/Burgers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBurger([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var burger = await _context.Burger.FindAsync(id);

            if (burger == null)
            {
                return NotFound();
            }

            return Ok(burger);
        }

        // PUT: api/Burgers/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutBurger([FromRoute] long id, [FromBody] Burger burger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != burger.Id)
            {
                return BadRequest();
            }

            _context.Entry(burger).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BurgerExists(id))
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

        // POST: api/Burgers
        [HttpPost]
        public async Task<IActionResult> PostBurger([FromBody] Burger burger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Burger.Add(burger);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetBurger", new { id = burger.Id }, burger);
        }

        // DELETE: api/Burgers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBurger([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var burger = await _context.Burger.FindAsync(id);
            if (burger == null)
            {
                return NotFound();
            }

            _context.Burger.Remove(burger);
            await _context.SaveChangesAsync();

            return Ok(burger);
        }

        private bool BurgerExists(long id)
        {
            return _context.Burger.Any(e => e.Id == id);
        }
    }
}