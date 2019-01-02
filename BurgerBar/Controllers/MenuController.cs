using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using BurgerBar.Services;
using BurgerBar.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BurgerBar.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly IBurgersService _burgersService;
        private readonly IProductsService _productsService;
        private readonly IMapper _mapper;

        public MenuController(IBurgersService burgersService, IProductsService productsService, IMapper mapper)
        {
            _burgersService = burgersService;
            _productsService = productsService;
            _mapper = mapper;
        }

        // GET: api/Menu/burgers
        [HttpGet("burger")]
        public async Task<IEnumerable<BurgerDTO>> GetBurgers()
        {
            var burgers = await _burgersService.GetAllInMenuAsync();
            var model = _mapper.Map<IEnumerable<BurgerDTO>>(burgers);
            return model;
        }

        // GET: api/Menu/other-products
        [HttpGet("other-product")]
        public async Task<IEnumerable<OtherProductDTO>> GetOtherProducts()
        {
            var products = await _productsService.GetAllInMenuAsync();
            var model = _mapper.Map<IEnumerable<OtherProductDTO>>(products);
            return model;
        }

        [HttpPost("product")]
        [Authorize]
        public async Task<IActionResult> AddProductToMenu([FromBody] long id)
        {
            var product = await _productsService.SetProductInMenu(id, true);
            return Ok(product.IsInMenu);
        }

        [HttpDelete("product/{id}")]
        [Authorize]
        public async Task<IActionResult> DeleteProductFromMenu([FromRoute] long id)
        {
            var product = await _productsService.SetProductInMenu(id, false);
            return Ok(product.IsInMenu);
        }
    }
}