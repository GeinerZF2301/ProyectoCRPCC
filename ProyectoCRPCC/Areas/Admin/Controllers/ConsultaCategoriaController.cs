using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace WebEmbalaje.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ConsultaCategoriaController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ConsultaCategoriaController(IUnidadTrabajo unidadTrabajo,
            IWebHostEnvironment hostEnvironment)
        {
            _unidadTrabajo = unidadTrabajo;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Upsert(int? id)
        {
            Categoria categoria = new Categoria();
            if (id == null)
            {
                //Esto es para crear una nueva bodega (insert)
                return View(categoria);
            }
            //actualizamos un registro Bodega existente
            categoria = _unidadTrabajo.Categoria.Obtener(id.GetValueOrDefault());
            if (categoria == null)
            {
                return NotFound();
            }
            return View(categoria);
        }
    }
}
