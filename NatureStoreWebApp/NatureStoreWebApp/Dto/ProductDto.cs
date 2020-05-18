using NatureStoreWebApp.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NatureStoreWebApp.Dto
{
    public class ProductDto
    {
        public Product Product { get; set; }
        public List<Disease> Diseases { get; set; }
        public List<Ingredient> Ingredients { get; set; }

        public ProductDto()
        {
        }

        public ProductDto(Product product, List<Disease> diseases, List<Ingredient> ingredients)
        {
            Product = product;
            Diseases = diseases;
            Ingredients = ingredients;
        }
    }
}
