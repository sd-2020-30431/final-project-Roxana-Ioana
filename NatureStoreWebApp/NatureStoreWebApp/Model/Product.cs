using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NatureStoreWebApp.Model
{
    public class Product
    {
        [Key]
        public int Id_product { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(1000)")]
        public string Administration { get; set; }
        public List<ProductIngredient> ProductIngredient { get; set; }
        public List<ProductDisease> ProductDisease { get; set; }

        public Product()
        {
            ProductIngredient = new List<ProductIngredient>();
            ProductDisease = new List<ProductDisease>();
        }

        public Product(int id_product, string name, float price, int stock, string description, string administration)
        {
            Id_product = id_product;
            Name = name;
            Price = price;
            Stock = stock;
            Description = description;
            Administration = administration;
        }
    }
}
