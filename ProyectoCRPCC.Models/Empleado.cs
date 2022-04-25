using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Models
{
    public class Empleado
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido 1: ")]
        public string Apellido1 { get; set; }
        [Required]
        [StringLength(50)]
        [Display(Name = "Apellido2: ")]
        public string Apellido2 { get; set; }
        [Required]
        [MaxLength(10)]
        [Display(Name = "Cédula : ")]
        public int Cedula { get; set; }
        [Required]
        [StringLength(100)]
        [Display(Name = "Direccion: ")]
        public string Direccion { get; set; }
        [Required]
        [StringLength(50)]
        
        [Display(Name = "Correo Electrónico: ")]
        public string Email { get; set; }
        [Required]
        [MaxLength(20)]
        [Display(Name = "Número de Teléfono: ")]
        public string NumeroTelefono { get; set; }
        
        //Llave foranea
        public int SucursalId { get; set; }
        [ForeignKey("SucursalId")]
        public Sucursal Sucursal { get; set; }
        






    }
}
