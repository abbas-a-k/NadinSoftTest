using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace api.Model
{
    public class Products
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MinLength(3),MaxLength(20)]
        public string Name { get; set; } = string.Empty;
        [Required]
        [DataType(DataType.Date)]
        public DateTime ProductDate { get; set; }
        [Required]
        [Phone]
        public string ManufacturePhone { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        public string ManufactureEmail { get; set; } = string.Empty;
        [Required]
        public bool IsAvalable { get; set; } = true;
        [Required]
        [ForeignKey(nameof(AppUser))]
        public string AppUserId { get; set; }
        public AppUser AppUser { get; set; }
    }
}