using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Data.Repositorio.IRepositorio
{
    internal interface IUnidadTrabajo : IDisposable
    {
        IClienteRepositorio Cliente { get; }
        IEmpleadoRepositorio Empleado { get; }
        ICategoriaRepositorio Categoria { get; }
        IServiciosRepositorio Servicios{ get; }
        ISucursalRepositorio Sucursal { get; }
        IProductoRepositorio Producto { get; }
        IUsuarioAplicacionRepositorio UsuarioAplicacion { get; }
        void Guardar();






    }
}
