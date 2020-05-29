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
        //[Column(TypeName = "nvarchar(100)")]
        //[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
        public string Name { get; set; }

        [Required]
        public float Price { get; set; }

        [Required]
        public int Stock { get; set; }

        [Required]
        //[Column(TypeName = "nvarchar(1000)")]
        [StringLength(200, MinimumLength = 3)]
        public string Description { get; set; }

        [Required]
        //[Column(TypeName = "nvarchar(1000)")]
        public string Administration { get; set; }
        public List<ProductIngredient> ProductIngredient { get; set; }
        public List<ProductDisease> ProductDisease { get; set; }

        //[DataType(DataType.Date)]

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

        public Product(string name, float price, int stock, string description, string administration)
        {
            Name = name;
            Price = price;
            Stock = stock;
            Description = description;
            Administration = administration;
        }

        /*
         *    { 
       "product": {
        "name": "Pills",
        "price": 29.99,
        "stock": 10,
        "description": "Very good for cold",
        "administration": "Two pills each morning",
        "productIngredient": null,
        "productDisease": null
        },
    	 "diseases":[{
        	 "id_disease": 1,
        	 "name": "Headache"
    	  }]
        ,
        "ingredients":[{
        	 "id_ingredient": 1,
        	 "name": "Mint"
    	  }]
   }
         */
    }
}
