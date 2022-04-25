using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Models.ViewModels
{
    public class ClienteVM
    {
        public Cliente Cliente { get; set; }    
        public IEnumerable<SelectListItem> ServiciosLista { get; set; }




    }
}
