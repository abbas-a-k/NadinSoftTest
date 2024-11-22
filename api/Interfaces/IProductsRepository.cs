using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Helper;
using api.Models;

namespace api.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Products>> GetAllProductsAsync(ProductsQueryObject query);
        Task<Products?> GetProductsByIdAsync(int productsId);
    }
}