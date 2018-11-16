using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BurgerBar.Data;
using BurgerBar.Entities;
using BurgerBar.Services;

namespace BurgerBar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BurgersController : ControllerBase
    {
        private readonly IBurgersService burgersService;

        public BurgersController(IBurgersService burgersService)
        {
            this.burgersService = burgersService;
        }

        // GET: api/Burgers
        [HttpGet]
        public async Task<IEnumerable<Burger>> GetAllBurgersAsync()
        {
            return await burgersService.GetAllAsync();
        }

        // GET: api/Burgers/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBurger([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var burger = await burgersService.GetAsync(id);

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

            burger = await burgersService.UpdateAsync(id, burger);

            if (burger == null)
            {
                return NotFound();
            }

            return Ok(burger);
        }

        // POST: api/Burgers
        [HttpPost]
        public async Task<IActionResult> PostBurger([FromBody] Burger burger)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await burgersService.AddAsync(burger);

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

            var burger = await burgersService.DeleteAsync(id);
            if (burger == null)
            {
                return NotFound();
            }

            return Ok(burger);
        }
    }
}