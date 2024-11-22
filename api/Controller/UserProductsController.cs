using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.UserProducts;
using api.Extensions;
using api.Interfaces;
using api.Mapper;
using api.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace api.Controller
{
    [Route("api/userproducts")]
    [ApiController]
    [Authorize]
    public class UserProductsController : ControllerBase
    {
        private readonly IUserProductsRepository _userProductsRepo;
        private readonly UserManager<AppUser> _userManager;
        public UserProductsController(IUserProductsRepository userProductsRepo, UserManager<AppUser> userManager)
        {
            _userProductsRepo = userProductsRepo;
            _userManager = userManager;
        }

        [HttpGet]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> GetUserProducts()
        {
            var userName = User.GetUsername();
            var appUserModel = await _userManager.FindByNameAsync(userName);
            var productsModel = await _userProductsRepo.GetUserProductsAsync(appUserModel);

            if (productsModel == null)
            {
                return NotFound();
            }

            return Ok(productsModel.toProductsDto());
        }

        [HttpPost("createproducts")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> CreateProducts([FromBody] CreateProductsDto productsDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var userName = User.GetUsername();
            var appUserModel = await _userManager.FindByNameAsync(userName);

            if(await _userProductsRepo.GetUserProductsAsync(appUserModel) != null)
            {
                return BadRequest();
            }

            var productsModel = productsDto.ToProductsFromCreate(appUserModel);

            var create = await _userProductsRepo.CreateProductsAsync(appUserModel, productsModel);

            if (create == null)
            {
                return BadRequest();
            }

            return Created();
        }

        [HttpPut("updateproducts")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> UpdateProducts([FromBody] CreateProductsDto productsDto)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState); 
            }

            var userName = User.GetUsername();
            var appUserModel = await _userManager.FindByNameAsync(userName);

            if(await _userProductsRepo.GetUserProductsAsync(appUserModel) == null)
            {
                return NotFound();
            }

            var productsModel = productsDto.ToProductsFromCreate(appUserModel);
            var update = await _userProductsRepo.UpdateProductsAsync(appUserModel,productsModel);

            if(update == null)
            {
                return NotFound();
            }

            return Ok(update.toProductsDto());
        }

        [HttpDelete("deleteproducts")]
        [Authorize(Roles = "User")]
        public async Task<IActionResult> DeleteProducts()
        {
            var userName = User.GetUsername();
            var appUserModel = await _userManager.FindByNameAsync(userName);

            if(await _userProductsRepo.GetUserProductsAsync(appUserModel) == null)
            {
                return NotFound();
            }

            var delete = await _userProductsRepo.DeleteProductsAsync(appUserModel);
            
            if(delete == null)
            {
                return NotFound();
            }

            return NoContent();
        }

    }
}