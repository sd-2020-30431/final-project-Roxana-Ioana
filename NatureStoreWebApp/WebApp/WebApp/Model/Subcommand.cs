using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class Subcommand
    {
        [Key]
        public int Id_subcommand { get; set; }
        public int CommandId_command { get; set; }
        public Command Command { get; set; }
        public int ProductId_product { get; set; }
        public Product Product { get; set; }
        public float Price { get; set; }

        public Subcommand(int commandId_command, int productId_product, float price)
        {
            CommandId_command = commandId_command;
            ProductId_product = productId_product;
            Price = price;
        }

        public Subcommand()
        {
        }
    }
}
