using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApp.Model;

namespace WebApp.Dto
{
    public class ProductDto
    {
        public int Id_product { get; set; }
        public string Name { get; set; }
        public float Price { get; set; }
        public int Stock { get; set; }
        public string Description { get; set; }
        public string Administration { get; set; }
        public List<Disease> Diseases { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public ProductDto()
        {
        }

        public ProductDto(int id_product, string name, float price, int stock, string description, string administration, List<Disease> diseases, List<Ingredient> ingredients)
        {
            Id_product = id_product;
            Name = name;
            Price = price;
            Stock = stock;
            Description = description;
            Administration = administration;
            Diseases = diseases;
            Ingredients = ingredients;
        }
    }
}
