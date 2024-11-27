using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositorys
{
    public class UserProductsRepository : IUserProductsRepository
    {
        private readonly ApplicationDBContext _context;
        public UserProductsRepository(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task<Products> CreateProductsAsync(AppUser appUserModel, Products productsModel)
        {
            if(await _context.Products.AnyAsync(e => e.AppUserId == appUserModel.Id))
            {
                return null;
            }

            await _context.Products.AddAsync(productsModel);
            await _context.SaveChangesAsync();
            return productsModel;
        }

        public async Task<Products?> DeleteProductsAsync(AppUser appUserModel)
        {
            var productsModel = await _context.Products
                .FirstOrDefaultAsync(e => e.AppUserId == appUserModel.Id);

            if(productsModel == null)
            {
                return null;
            }

            _context.Products.Remove(productsModel);
            await _context.SaveChangesAsync();

            return productsModel;
        }

        public async Task<Products?> GetUserProductsAsync(AppUser appUserModel)
        {
            return await _context.Products
                .Include(e => e.AppUser)
                .FirstOrDefaultAsync(e => e.AppUserId == appUserModel.Id);
        }

        public async Task<Products?> UpdateProductsAsync(AppUser appUserModel, Products productsModel)
        {
            var existingProducts = await _context.Products
                .FirstOrDefaultAsync(e => e.AppUserId == appUserModel.Id);

            if(existingProducts == null)
            {
                return null;
            }

            existingProducts.Name = productsModel.Name;
            existingProducts.ProductDate = productsModel.ProductDate;
            existingProducts.IsAvalable = productsModel.IsAvalable;

            await _context.SaveChangesAsync();

            return existingProducts;
        }
    }
}