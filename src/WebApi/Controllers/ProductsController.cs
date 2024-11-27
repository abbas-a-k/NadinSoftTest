using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Mapper;
using Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebApi.Helper;

namespace Application.Controllers
{
    [Route("api/products")]
    [ApiController]
    [AllowAnonymous]
    public class ProductsController : ControllerBase
    {
        private readonly IProductsRepository _productsRepo;
        public ProductsController(IProductsRepository productsRepo)
        {
            _productsRepo = productsRepo;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> GetAllProducts([FromQuery] ProductsQueryObject query)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var products = await _productsRepo.GetAllProductsAsync(query);
            var productsDto = products.Select(e => e.toProductsDto());

            return Ok(productsDto);
        }

        [HttpGet("{productsId:int}")]
        [AllowAnonymous]
        public async Task<IActionResult> GetProductsById ([FromRoute] int productsId)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var product = await _productsRepo.GetProductsByIdAsync(productsId);
            if(product == null)
            {
                return NotFound();
            }

            return Ok(product.toProductsDto());
        }
    }
}