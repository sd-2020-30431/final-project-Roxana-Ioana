using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class ProductContext : IdentityDbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<ProductIngredient>()
                .HasKey(t => new { t.Id_product, t.Id_ingredient });

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductIngredient)
                .HasForeignKey(pt => pt.Id_product);

            modelBuilder.Entity<ProductIngredient>()
                .HasOne(pt => pt.Ingredient)
                .WithMany(t => t.ProductIngredient)
                .HasForeignKey(pt => pt.Id_ingredient);

            modelBuilder.Entity<ProductDisease>()
               .HasKey(t => new { t.Id_product, t.Id_disease });

            modelBuilder.Entity<ProductDisease>()
                .HasOne(pt => pt.Product)
                .WithMany(p => p.ProductDisease)
                .HasForeignKey(pt => pt.Id_product);

            modelBuilder.Entity<ProductDisease>()
                .HasOne(pt => pt.Disease)
                .WithMany(t => t.ProductDisease)
                .HasForeignKey(pt => pt.Id_disease);
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Disease> Diseases { get; set; }
        public DbSet<Ingredient> Ingredients { get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }
        public DbSet<Command> Commands { get; set; }
        public DbSet<Subcommand> Subcommands { get; set; }
    }
}
