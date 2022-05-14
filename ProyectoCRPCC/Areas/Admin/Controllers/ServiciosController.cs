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
    public class ServiciosController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public ServiciosController(IUnidadTrabajo unidadTrabajo,
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

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            ServiciosVM serviciosVM = new ServiciosVM()
            {
                //Llena el combobox de compañías
                Servicios = new Servicios(),
                CategoriaLista =
                   _unidadTrabajo.Categoria.ObtenerTodos().Select(s =>
                           new SelectListItem
                           {
                               Text = s.Nombre,
                               Value = s.Id.ToString()
                           }),
            };


            if (id == null)
            {
                //Esto es para Crear nuevo Registro
                return View(serviciosVM);
            }
            //Esto es para Actualizar
            serviciosVM.Servicios = _unidadTrabajo.Servicios.Obtener(id.GetValueOrDefault());
            if (serviciosVM.Servicios == null)
            {
                return NotFound();
            }

            return View(serviciosVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(ServiciosVM serviciosVM)
        {
            if (ModelState.IsValid)
            {

                // Cargar Imagenes
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    Servicios serviciosDB = _unidadTrabajo.Servicios.Obtener(serviciosVM.Servicios.Id);
                    if (serviciosDB != null)
                        serviciosVM.Servicios.ImageUrl = serviciosDB.ImageUrl;


                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"imagenes\servicios");
                    var extension = Path.GetExtension(files[0].FileName);

                    if (serviciosVM.Servicios.ImageUrl != null)
                    {
                        //Esto es para editar, necesitamos borrar la imagen anterior
                        var imagenPath = Path.Combine(webRootPath, serviciosVM.Servicios.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagenPath))
                        {
                            System.IO.File.Delete(imagenPath);
                        }
                    }

                    using (var filesStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    serviciosVM.Servicios.ImageUrl = @"\imagenes\servicios\" + filename + extension;
                }
                else
                {
                    // Si en el Update el usuario no cambia la imagen
                    if (serviciosVM.Servicios.Id != 0)
                    {
                        Servicios serviciosDB = _unidadTrabajo.Servicios.Obtener(serviciosVM.Servicios.Id);
                        serviciosVM.Servicios.ImageUrl = serviciosDB.ImageUrl;
                    }
                }


                if (serviciosVM.Servicios.Id == 0)
                {
                    _unidadTrabajo.Servicios.Agregar(serviciosVM.Servicios);
                }
                else
                {
                    _unidadTrabajo.Servicios.Actualizar(serviciosVM.Servicios);
                }
                _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                serviciosVM.CategoriaLista = _unidadTrabajo.Categoria.ObtenerTodos().Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });


                if (serviciosVM.Servicios.Id != 0)
                {
                    serviciosVM.Servicios = _unidadTrabajo.Servicios.Obtener(serviciosVM.Servicios.Id);
                }

            }
            return View(serviciosVM.Servicios);
        }
        #region API
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = _unidadTrabajo.Servicios.ObtenerTodos(IncluirPropiedades: "Categoria");
            return Json(new { data = todos });
        }
        #endregion
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var serviciosDb = _unidadTrabajo.Servicios.Obtener(id);
            if (serviciosDb == null)
            {
                return Json(new { success = false, message = "Error al borrar la categoría " });
            }
            else
                _unidadTrabajo.Servicios.Remover(serviciosDb);
            _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Categoría borrada exitosamente" });
        }

    }
}
