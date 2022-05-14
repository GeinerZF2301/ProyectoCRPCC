using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Models
{
    public class Servicios
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre del Servicio: ")]
        public string NombreServicio { get; set; }
        [StringLength(50)]
        [Display(Name = "Descripción: ")]
        public string Descripcion { get; set; }
        [Required]
        [Display(Name ="Estado")]
        public bool Estado { get; set; }
        public string ImageUrl { get; set; }

        public int IdCategoria { get; set; }
        [ForeignKey("IdCategoria")]
        public Categoria Categoria { get; set; }

    }
}
