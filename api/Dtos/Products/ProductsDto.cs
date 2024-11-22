using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Products
{
    public class ProductsDto
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string ManufactureName { get; set; } = string.Empty;
        public DateTime ProductDate { get; set; }
        public string ManufacturePhone { get; set; } = string.Empty;
        public string ManufactureEmail { get; set; } = string.Empty;
        public bool IsAvalable { get; set; } = true;
    }
}