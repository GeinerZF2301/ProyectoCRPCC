using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Models
{
    public class ServicioDetalle
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [Display(Name = "Cantidad: ")]
        public int Cantidad { get; set; }
        [Required]
        [Display(Name = "Fecha Inicial: ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MM-dd-yyyy HH:mm}")]
        public DateTime FechaInicial { get; set; }
        [Required]
        [Display(Name = "Fecha Final: ")]
        [DisplayFormat(ApplyFormatInEditMode = false, DataFormatString = "{0:MM-dd-yyyy HH:mm}")]
        public DateTime FechaFinal { get; set; }
        //Llaves foraneas

        public int IdServicio { get; set; }
        [ForeignKey("IdServicio")]
        public Servicios Servicios { get; set; }
        public int IdSucursal { get; set; }
        [ForeignKey("IdSucursal")]
        public Sucursal Sucursal{ get; set; }
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]
        public Producto Producto { get; set; }


    }
}
