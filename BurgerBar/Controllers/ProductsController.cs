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
    public class ProductsController : ControllerBase
    {
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public ProductsController(IProductsService productsService, IMapper mapper)
        {
            _productsService = productsService;
            _mapper = mapper;
        }

        // GET: api/Products
        [HttpGet]
        [Authorize]
        public async Task<IEnumerable<OtherProductDTO>> GetProducts()
        {
            var products = await _productsService.GetAllAsync();
            var model = _mapper.Map<IEnumerable<OtherProductDTO>>(products);
            return model;
        }

        // GET: api/Products/menu
        [HttpGet("menu")]
        public async Task<IEnumerable<OtherProductDTO>> GetMenuProducts()
        {
            var products = await _productsService.GetAllInMenuAsync();
            var model = _mapper.Map<IEnumerable<OtherProductDTO>>(products);
            return model;
        }

        // GET: api/Products/5
        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productsService.GetAsync(id);

            if (product == null)
            {
                return NotFound();
            }

            return Ok(product);
        }

        // PUT: api/Products/5
        [HttpPut("{id}")]
        [Authorize]
        public async Task<IActionResult> PutProduct([FromRoute] long id, [FromBody] OtherProduct product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != product.Id)
            {
                return BadRequest();
            }

            product = await _productsService.UpdateAsync(id, product);

            if (product == null)
            {
                return NotFound();
            }

            var model = _mapper.Map<OtherProductDTO>(product);

            return Ok(model);
        }

        // POST: api/Products
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> PostProduct([FromBody] OtherProduct product)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            await _productsService.AddAsync(product);
            var model = _mapper.Map<OtherProductDTO>(product);

            return CreatedAtAction("GetProduct", new { id = product.Id }, model);
        }

        // DELETE: api/Products/5
        [HttpDelete("{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProduct([FromRoute] long id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productsService.DeleteAsync(id);
            if (product == null)
            {
                return NotFound();
            }
            var model = _mapper.Map<OtherProductDTO>(product);

            return Ok(model);
        }

        // GET: api/Products/types
        [HttpGet("types")]
        public async Task<IEnumerable<ProductType>> GetProductTypes()
        {
            return await _productsService.GetProductTypes();
        }
    }
}