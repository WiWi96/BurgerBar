using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BurgerBar.Entities;
using BurgerBar.Services;

namespace BurgerBar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BunsController : ControllerBase
    {
        private readonly IBunsService bunsService;

        public BunsController(IBunsService bunsService)
        {
            this.bunsService = bunsService;
        }

        // GET: api/Buns
        [HttpGet]
        public async Task<IEnumerable<Bun>> GetBun()
        {
            return await bunsService.GetAllAsync();
        }

        // GET: api/Buns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBun([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bun = await bunsService.GetAsync(id);

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

            bun = await bunsService.UpdateAsync(id, bun);

            if (bun == null)
            {
                return NotFound();
            }

            return Ok(bun);
        }

        // POST: api/Buns
        [HttpPost]
        public async Task<IActionResult> PostBun([FromBody] Bun bun)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await bunsService.AddAsync(bun);

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

            var bun = await bunsService.DeleteAsync(id);
            if (bun == null)
            {
                return NotFound();
            }

            return Ok(bun);
        }
    }
}