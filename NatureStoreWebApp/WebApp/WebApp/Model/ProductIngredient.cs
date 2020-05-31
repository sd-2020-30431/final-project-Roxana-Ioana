using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class ProductIngredient
    {
        public int Id_product { get; set; }
        public Product Product { get; set; }

        public int Id_ingredient { get; set; }
        public Ingredient Ingredient { get; set; }

        public ProductIngredient(int id_product, int id_ingredient)
        {
            Id_product = id_product;
            Id_ingredient = id_ingredient;
        }
    }
}
