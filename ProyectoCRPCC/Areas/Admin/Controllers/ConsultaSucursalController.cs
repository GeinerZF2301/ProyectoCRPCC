using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;

namespace ProyectoCRPCC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ConsultaSucursalController : Controller
    {

        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _hostEnvironment;
        public ConsultaSucursalController(IUnidadTrabajo unidadTrabajo,
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
            Sucursal sucursal = new Sucursal();
            if (id == null)
            {
                //Esto es para crear una nueva bodega (insert)
                return View(sucursal);
            }
            //actualizamos un registro Bodega existente
            sucursal = _unidadTrabajo.Sucursal.Obtener(id.GetValueOrDefault());
            if (sucursal == null)
            {
                return NotFound();
            }
            return View(sucursal);
        }
    }
}
