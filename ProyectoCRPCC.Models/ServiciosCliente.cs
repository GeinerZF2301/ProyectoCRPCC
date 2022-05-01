using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Models
{
    public class ServiciosCliente
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre Servicio Brindado")]
        public string NombreServicio { get; set; }
        [Required]
        [Display(Name = "Fecha: ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MM-dd-yyyy HH:mm}")]
        
        public DateTime Fecha { get; set; }

        //Llaves foraneas
        public int IdCliente { get; set; }
        [ForeignKey("IdCliente")]
        public Cliente Cliente { get; set; }
        public int IdServicio{ get; set; }
        


    }
}
