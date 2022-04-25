using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Models
{
   public class Sucursal
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre: ")]
        public string Direccion { get; set; }
        [Required]
        public bool Estado { get; set; }







    }
}
