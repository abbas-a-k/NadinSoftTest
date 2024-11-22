using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;

namespace api.Interfaces
{
    public interface IUserProductsRepository
    {
        Task<Products?> GetUserProductsAsync (AppUser appUserModel);
        Task<Products> CreateProductsAsync(AppUser appUserModel, Products productsModel);
        Task<Products?> UpdateProductsAsync(AppUser appUserModel, Products productsModel);
        Task<Products?> DeleteProductsAsync(AppUser appUserModel);
    }
}