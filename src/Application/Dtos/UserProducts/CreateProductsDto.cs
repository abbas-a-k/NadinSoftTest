using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Application.Dtos.UserProducts
{
    public class CreateProductsDto
    {
        [Required]
        [MinLength(3),MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductDate { get; set; }
        [Required]
        public bool IsAvalable { get; set; } = true;
    }
}