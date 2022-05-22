using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;
using ProyectoCRPCC.Models.ViewModels;
using System.Linq;

namespace ProyectoCRPCC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ConsultaServiciosController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ConsultaServiciosController(IUnidadTrabajo unidadTrabajo,
            IWebHostEnvironment hostEnvironment)
        {
            _unidadTrabajo = unidadTrabajo;
            _hostEnvironment = hostEnvironment;
        }
        public IActionResult Index()
        {
            var servicios = _unidadTrabajo.Servicios.ObtenerTodos();
            return View(servicios);
        }

        public IActionResult Upsert(int? id)
        {
            ServiciosVM serviciosVM = new ServiciosVM()
            {
                //Llena el combobox de Servicios
                Servicios= new Servicios(),
                CategoriaLista =
                  _unidadTrabajo.Categoria.ObtenerTodos().Select(c =>
                          new SelectListItem
                          {
                              Text = c.Nombre,
                              Value = c.Id.ToString()
                          }),
            };
            //actualizamos un registro Bodega existente
            serviciosVM.Servicios = _unidadTrabajo.Servicios.Obtener(id.GetValueOrDefault());
            if (serviciosVM == null)
            {
                return NotFound();
            }
            return View(serviciosVM);
        }
    }
}
