using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BurgerBar.Entities;
using BurgerBar.Services;
using BurgerBar.ViewModels;
using AutoMapper;

namespace BurgerBar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BunsController : ControllerBase
    {
        private readonly IBunsService _bunsService;
        private readonly IMapper _mapper;

        public BunsController(IBunsService bunsService, IMapper mapper)
        {
            _bunsService = bunsService;
            _mapper = mapper;
        }

        // GET: api/Buns
        [HttpGet]
        public async Task<IEnumerable<BunDTO>> GetBuns()
        {
            var buns = await _bunsService.GetAllAsync();
            var model = _mapper.Map<IEnumerable<BunDTO>>(buns);
            return model;
        }

        // GET: api/Buns/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBun([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bun = await _bunsService.GetAsync(id);

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

            bun = await _bunsService.UpdateAsync(id, bun);

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

            await _bunsService.AddAsync(bun);
            var model = _mapper.Map<BunDTO>(bun);

            return CreatedAtAction("GetBun", new { id = bun.Id }, model);
        }

        // DELETE: api/Buns/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBun([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var bun = await _bunsService.DeleteAsync(id);
            if (bun == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<BunDTO>(bun);

            return Ok(model);
        }
    }
}