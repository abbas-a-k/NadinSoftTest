using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class ApplicationDBContext : IdentityDbContext<AppUser>
    {
        public ApplicationDBContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }
        public DbSet<Products> Products { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            // Products unique Key *BEGIN*
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
        }
    }
}