using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dtos.Products;
using Domain.Models;

namespace Application.Mapper
{
    public static class ProductsMapper
    {
        public static ProductsDto toProductsDto(this Products productsModel)
        {
            return new ProductsDto
            {
                Id = productsModel.Id,
                Name = productsModel.Name,
                ManufactureName = productsModel.AppUser.UserName,
                ProductDate = productsModel.ProductDate,
                ManufacturePhone = productsModel.ManufacturePhone,
                ManufactureEmail = productsModel.ManufactureEmail,
                IsAvalable = productsModel.IsAvalable
            };
        }
    }
}