using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Products> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Products unique key *BEGIN*
            builder.Entity<Products>()
                .HasIndex(k => new {k.ProductDate , k.ManufactureEmail})
                .IsUnique();
            // Products unique key *END*

            // AppUser-Products one to one relationship *BEGIN*
            builder.Entity<AppUser>()
                .HasOne(o => o.Products)
                .WithOne(w => w.AppUser)
                .HasForeignKey<Products>(f => f.AppUserId)
                .IsRequired();
            // AppUser-Products one to one relationship *END*

            //JWT Setup *BEGIN*
            base.OnModelCreating(builder);
            List<IdentityRole> roles = new List<IdentityRole>
            {
                new IdentityRole
                {
                    Name = "User",
                    NormalizedName = "USER"
                },
            };
            builder.Entity<IdentityRole>().HasData(roles);
            //JWT Setup *END*
        }
    }
}