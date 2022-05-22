using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;
using ProyectoCRPCC.Models.ViewModels;
using System.Linq;

namespace ProyectoCRPCC.Areas.Admin.Controllers
{
    [Area ("Admin")]
    public class ConsultaClienteController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ConsultaClienteController(IUnidadTrabajo unidadTrabajo,
             IWebHostEnvironment hostEnvironment)
        {
            _unidadTrabajo = unidadTrabajo;
            _hostEnvironment = hostEnvironment;
        }



        public IActionResult Index()
        {
            var cliente = _unidadTrabajo.Cliente.ObtenerTodos();
            return View(cliente);

        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ClienteVM clienteVM = new ClienteVM()
            {
                //Llena el combobox de Servicios
                Cliente = new Cliente(),
                ServiciosLista =
                   _unidadTrabajo.Servicios.ObtenerTodos().Select(c =>
                           new SelectListItem
                           {
                               Text = c.NombreServicio,
                               Value = c.Id.ToString()
                           }),
            };

            if (id == null)
            {
                //Esto es para Crear nuevo Registro
                return View(clienteVM);
            }
            //Esto es para Actualizar
            clienteVM.Cliente = _unidadTrabajo.Cliente.Obtener(id.GetValueOrDefault());
            if (clienteVM.Cliente == null)
            {
                return NotFound();
            }

            return View(clienteVM);
        }
    }
}
