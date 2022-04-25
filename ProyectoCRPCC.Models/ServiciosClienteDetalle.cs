using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Models
{
    public class ServiciosClienteDetalle
    {
        [Key]
        public int IdServiciosClienteDetalle { get; set; }
        [Required]
        [Range(1, 1000000)]
        [Display(Name = "Precio")]
        public double Precio { get; set; }
        [Required]
        [Display(Name ="Cantidad")]
        public int Cantidad { get; set; }

        //Llaves Foraneas

        public int IdServiciosCliente { get; set; }
        [ForeignKey("IdServiciosCliente")]
        public ServiciosCliente ServiciosCliente { get; set; }

        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]  
        public Producto Producto { get; set; }





    }
}
