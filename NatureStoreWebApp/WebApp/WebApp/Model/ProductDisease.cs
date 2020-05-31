using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class ProductDisease
    {
        public int Id_product { get; set; }
        public Product Product { get; set; }

        public int Id_disease { get; set; }
        public Disease Disease { get; set; }
        public ProductDisease(int id_product, int id_disease)
        {
            Id_product = id_product;
            Id_disease = id_disease;
        }
    }
}
