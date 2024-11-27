using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Interfaces;
using Domain.Models;
using Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using WebApi.Helper;

namespace Infrastructure.Repositorys
{
    public class ProductRepository : IProductsRepository
    {
        private readonly ApplicationDBContext _context;
        public ProductRepository(ApplicationDBContext context)
        {
            _context = context;
        }
        public async Task<List<Products>> GetAllProductsAsync(ProductsQueryObject query)
        {
            var products = _context.Products.Include(e => e.AppUser).AsQueryable();

            if(!string.IsNullOrWhiteSpace(query.manufactureName))
            {
                products = products.Where(e => e.AppUser.UserName.Contains(query.manufactureName));
            }

            return await products.ToListAsync();
        }

        public async Task<Products> GetProductsByIdAsync(int productsId)
        {
            return await _context.Products
                .Include(e => e.AppUser)
                .FirstOrDefaultAsync(e => e.Id == productsId);
        }
    }
}