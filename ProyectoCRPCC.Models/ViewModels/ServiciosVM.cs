using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Models.ViewModels
{
    public class ServiciosVM
    {
        public Servicios Servicios { get; set; }
        public ServicioDetalle ServicioDetalle { get; set; }
        public IEnumerable<SelectListItem> CategoriaLista { get; set; }
        
    }
}
