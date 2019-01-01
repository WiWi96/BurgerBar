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
using AutoMapper;
using BurgerBar.ViewModels;
using Microsoft.AspNetCore.Authorization;

namespace BurgerBar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IngredientsController : ControllerBase
    {
        private readonly IIngredientsService _ingredientsService;
        private readonly IMapper _mapper;

        public IngredientsController(IIngredientsService ingredientsService, IMapper mapper)
        {
            _ingredientsService = ingredientsService;
            _mapper = mapper;
        }

        // GET: api/Ingredients
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<IngredientDTO>> GetAllIngredients()
        {
            IEnumerable<Ingredient> ingredients = await _ingredientsService.GetAllAsync();
            var model = _mapper.Map<IEnumerable<IngredientDTO>>(ingredients);
            return model;
        }

        // GET: api/Ingredients/available
        [HttpGet("available")]
        public async Task<IEnumerable<IngredientDTO>> GetAvailableIngredients()
        {
            IEnumerable<Ingredient> ingredients = await _ingredientsService.GetAllAvailableAsync();
            var model = _mapper.Map<IEnumerable<IngredientDTO>>(ingredients);
            return model;
        }

        // GET: api/Ingredients/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetIngredient([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ingredient = await _ingredientsService.GetAsync(id);

            if (ingredient == null)
            {
                return NotFound();
            }

            return Ok(ingredient);
        }

        // PUT: api/Ingredients/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutIngredient([FromRoute] long id, [FromBody] Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ingredient.Id)
            {
                return BadRequest();
            }

            ingredient = await _ingredientsService.UpdateAsync(id, ingredient);

            if (ingredient == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<IngredientDTO>(ingredient);
            return Ok(model);
        }

        // POST: api/Ingredients
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostIngredient([FromBody] Ingredient ingredient)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _ingredientsService.AddAsync(ingredient);
            var model = _mapper.Map<IngredientDTO>(ingredient);

            return CreatedAtAction("GetIngredient", new { id = ingredient.Id }, model);
        }

        // DELETE: api/Ingredients/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteIngredient([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var ingredient = await _ingredientsService.DeleteAsync(id);
            if (ingredient == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<IngredientDTO>(ingredient);

            return Ok(model);
        }

        // GET: api/Ingredients/types
        [HttpGet("types")]
        public async Task<IEnumerable<IngredientType>> GetIngredientTypes()
        {
            return await _ingredientsService.GetIngredientTypes();
        }
    }
}