using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using WebApi.Helper;

namespace Domain.Interfaces
{
    public interface IProductsRepository
    {
        Task<List<Products>> GetAllProductsAsync(ProductsQueryObject query);
        Task<Products?> GetProductsByIdAsync(int productsId);
    }
}