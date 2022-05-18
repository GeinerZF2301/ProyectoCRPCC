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
    public class EmpleadoController : Controller
    {
        private readonly IUnidadTrabajo _unidadTrabajo;
        private readonly IWebHostEnvironment _hostEnvironment;

        public EmpleadoController(IUnidadTrabajo unidadTrabajo,
             IWebHostEnvironment hostEnvironment)
        {
            _unidadTrabajo = unidadTrabajo;
            _hostEnvironment = hostEnvironment;
        }



        public IActionResult Index()
        {
            var empleado = _unidadTrabajo.Empleado.ObtenerTodos();
            return View(empleado);

        }

        [HttpGet]
        public IActionResult Upsert(int? id)
        {
            EmpleadoVM empleadoVM = new EmpleadoVM()
            {
                //Llena el combobox de Servicios
                Empleado = new Empleado(),
                SucursalesLista =
                   _unidadTrabajo.Sucursal.ObtenerTodos().Select(c =>
                           new SelectListItem
                           {
                               Text = c.Nombre,
                               Value = c.Id.ToString()
                           }),
            };

            if (id == null)
            {
                //Esto es para Crear nuevo Registro
                return View(empleadoVM);
            }
            //Esto es para Actualizar
            empleadoVM.Empleado = _unidadTrabajo.Empleado.Obtener(id.GetValueOrDefault());
            if (empleadoVM.Empleado == null)
            {
                return NotFound();
            }

            return View(empleadoVM);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Upsert(EmpleadoVM empleadoVM)
        {
            if (ModelState.IsValid)
            {

                // Cargar Imagenes
                string webRootPath = _hostEnvironment.WebRootPath;
                var files = HttpContext.Request.Form.Files;
                if (files.Count > 0)
                {
                    Empleado empleadoDB = _unidadTrabajo.Empleado.Obtener(empleadoVM.Empleado.Id);
                    if (empleadoDB != null)
                        empleadoVM.Empleado.ImageUrl = empleadoDB.ImageUrl;


                    string filename = Guid.NewGuid().ToString();
                    var uploads = Path.Combine(webRootPath, @"imagenes\empleados");
                    var extension = Path.GetExtension(files[0].FileName);

                    if (empleadoVM.Empleado.ImageUrl != null)
                    {
                        //Esto es para editar, necesitamos borrar la imagen anterior
                        var imagenPath = Path.Combine(webRootPath, empleadoVM.Empleado.ImageUrl.TrimStart('\\'));
                        if (System.IO.File.Exists(imagenPath))
                        {
                            System.IO.File.Delete(imagenPath);
                        }
                    }

                    using (var filesStreams = new FileStream(Path.Combine(uploads, filename + extension), FileMode.Create))
                    {
                        files[0].CopyTo(filesStreams);
                    }
                    empleadoVM.Empleado.ImageUrl = @"\imagenes\empleados\" + filename + extension;
                }
                else
                {
                    // Si en el Update el usuario no cambia la imagen
                    if (empleadoVM.Empleado.Id != 0)
                    {
                        Empleado empleadoDB = _unidadTrabajo.Empleado.Obtener(empleadoVM.Empleado.Id);
                        empleadoVM.Empleado.ImageUrl = empleadoDB.ImageUrl;
                    }
                }


                if (empleadoVM.Empleado.Id == 0)
                {
                    _unidadTrabajo.Empleado.Agregar(empleadoVM.Empleado);
                }
                else
                {
                    _unidadTrabajo.Empleado.Actualizar(empleadoVM.Empleado);
                }
                _unidadTrabajo.Guardar();
                return RedirectToAction(nameof(Index));
            }
            else
            {
                empleadoVM.SucursalesLista = _unidadTrabajo.Sucursal.ObtenerTodos().Select(c => new SelectListItem
                {
                    Text = c.Nombre,
                    Value = c.Id.ToString()
                });


                if (empleadoVM.Empleado.Id != 0)
                {
                    empleadoVM.Empleado = _unidadTrabajo.Empleado.Obtener(empleadoVM.Empleado.Id);
                }

            }
            return View(empleadoVM.Empleado);
        }
        #region API
        [HttpGet]
        public IActionResult ObtenerTodos()
        {
            var todos = _unidadTrabajo.Empleado.ObtenerTodos(IncluirPropiedades: "Sucursal");
            return Json(new { data = todos });
        }
        #endregion
        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var empleadoDb = _unidadTrabajo.Empleado.Obtener(id);
            if (empleadoDb == null)
            {
                return Json(new { success = false, message = "Error al borrar el empleado " });
            }
            else
                _unidadTrabajo.Empleado.Remover(empleadoDb);
            _unidadTrabajo.Guardar();
            return Json(new { success = true, message = "Empleado borrado exitosamente" });
        }

    }
}
