using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class Disease
    {
        [Key]
        public int Id_disease { get; set; }

        [Required]
        [Column(TypeName = "nvarchar(100)")]
        public String Name { get; set; }

        public List<ProductDisease> ProductDisease { get; set; }

        public Disease()
        {
        }

        public Disease(int id_disease, string name)
        {
            Id_disease = id_disease;
            Name = name;
        }
    }
}
