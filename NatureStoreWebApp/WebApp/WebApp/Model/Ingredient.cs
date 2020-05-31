using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class Ingredient
    {
        [Key]
        public int Id_ingredient { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public String Name { get; set; }

        public List<ProductIngredient> ProductIngredient { get; set; }

        public Ingredient()
        {
        }

        public Ingredient(int id_ingredient, string name)
        {
            Id_ingredient = id_ingredient;
            Name = name;
        }
    }
}
