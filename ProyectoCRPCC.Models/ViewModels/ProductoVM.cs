﻿using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoCRPCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.Models.ViewModels
{
    public class ProductoVM
    {
        public Producto Producto { get; set; }
        public IEnumerable<SelectListItem> PadreLista { get; set; }
        public IEnumerable<Producto> ProductoLista { get; set; }
    }
}
