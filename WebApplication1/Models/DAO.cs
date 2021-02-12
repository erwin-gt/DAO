using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class DAO
    {
        [Key]
        [Display(Name ="Codigo Usuario")]
        [Required]
        public int ID { get; set; }

        [Required]
        public String Nombre { get; set; }

        [Required]
        public String Apellido { get; set; }

        [Required]
        public String Correo { get; set; }

        [Required]
        public String Direccion { get; set; }

        [Required]
        public String Telefono { get; set; }
    }
}
