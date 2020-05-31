using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApp.Model
{
    public class Command
    {
        [Key]
        public int Id_command { get; set; }
        public string ApplicationUserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        [Required]
        public float Price { get; set; }

        public List<Subcommand> Subcommands { get; set; }
    }
}
