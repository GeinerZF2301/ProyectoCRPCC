using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;
using ProyectoCRPCC.Models.ViewModels;
using System;
using System.IO;
using System.Linq;

namespace ProyectoCRPCC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ClienteController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ClienteController(IUnidadTrabajo unidadTrabajo,
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
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ClienteVM clienteVM)
        {
            if (ModelState.IsValid)
            {

                // Cargar Imagenes
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    Cliente clienteDB = _unidadTrabajo.Cliente.Obtener(clienteVM.Cliente.Id);
                    if (clienteDB != null)
                        clienteVM.Cliente.ImageUrl = clienteDB.ImageUrl;


                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"imagenes\clientes");
                    var extension = Path.GetExtension(files[0].FileName);

                    if (clienteVM.Cliente.ImageUrl != null)
                    {
                        //Esto es para editar, necesitamos borrar la imagen anterior
                        var imagenPath = Path.Combine(webRootPath, clienteVM.Cliente.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagenPath))
                        {
                            System.IO.File.Delete(imagenPath);
                        }
                    }

                    using (var filesStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    clienteVM.Cliente.ImageUrl = @"\imagenes\clientes\" + filename + extension;
                }
                else
                {
                    // Si en el Update el usuario no cambia la imagen
                    if (clienteVM.Cliente.Id != 0)
                    {
                        Cliente clienteDB = _unidadTrabajo.Cliente.Obtener(clienteVM.Cliente.Id);
                        clienteVM.Cliente.ImageUrl = clienteDB.ImageUrl;
                    }
                }


                if (clienteVM.Cliente.Id == 0)
                {
                    _unidadTrabajo.Cliente.Agregar(clienteVM.Cliente);
                }
                else
                {
                    _unidadTrabajo.Cliente.Actualizar(clienteVM.Cliente);
                }
                _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                clienteVM.ServiciosLista = _unidadTrabajo.Servicios.ObtenerTodos().Select(c => new SelectListItem
                {
                    Text = c.NombreServicio,
                    Value = c.Id.ToString()
                });


                if (clienteVM.Cliente.Id != 0)
                {
                    clienteVM.Cliente = _unidadTrabajo.Cliente.Obtener(clienteVM.Cliente.Id);
                }

            }
            return View(clienteVM.Cliente);
        }
        #region API
            [HttpGet]
            public IActionResult ObtenerTodos()
            {
                var todos = _unidadTrabajo.Cliente.ObtenerTodos(IncluirPropiedades: "Servicios");
                return Json(new { data = todos });
            }
            #endregion
            [HttpDelete]
            public IActionResult Delete(int id)
            {
                var clienteDb = _unidadTrabajo.Cliente.Obtener(id);
                    if (clienteDb == null)
                    {
                        return Json(new { success = false, message = "Error al borrar el cliente " });
                    }
                    else
                        _unidadTrabajo.Cliente.Remover(clienteDb);
                    _unidadTrabajo.Guardar();
                    return Json(new { success = true, message = "Cliente borrado exitosamente" });
            }

    }
}
