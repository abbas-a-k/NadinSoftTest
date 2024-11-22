using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.UserProducts;
using api.Models;

namespace api.Mapper
{
    public static class UserProductsMapper
    {
        public static Products ToProductsFromCreate (this CreateProductsDto userProductsDto , AppUser appUserModel)
        {
            return new Products 
            {
                Name = userProductsDto.Name,
                ProductDate = userProductsDto.ProductDate,
                ManufacturePhone = appUserModel.PhoneNumber,
                ManufactureEmail = appUserModel.Email,
                IsAvalable = userProductsDto.IsAvalable,
                AppUserId = appUserModel.Id,
                AppUser = appUserModel
            };
        }
    }
}