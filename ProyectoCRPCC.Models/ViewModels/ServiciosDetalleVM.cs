using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Models.ViewModels
{
    public class ServiciosDetalleVM
    {
        public Servicios Servicios { get; set; }
        public ServicioDetalle ServicioDetalle { get; set; }
        public List<ServicioDetalle> ServicioDetalles { get; set; }
        public IEnumerable<SelectListItem> ProductoLista { get; set; }
        public IEnumerable<SelectListItem> SucursalLista { get; set; }
        public IEnumerable<SelectListItem> CategoriaLista { get; set; }




    }
}
