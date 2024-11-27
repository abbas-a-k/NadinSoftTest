using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Helper
{
    public class ProductsQueryObject
    {
        [MinLength(3),MaxLength(20)]
        public string? manufactureName { get; set; }
    }
}