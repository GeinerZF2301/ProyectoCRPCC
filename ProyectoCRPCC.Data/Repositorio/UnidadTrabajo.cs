using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Data.Repositorio
{
    public class UnidadTrabajo : IUnidadTrabajo
    {
        private readonly ApplicationDbContext _db;
        public IClienteRepositorio Cliente { get; set; }
        public ICategoriaRepositorio Categoria { get; set; }
        public IEmpleadoRepositorio Empleado { get; set; }

        public IProductoRepositorio Producto { get; set; }

        public IUsuarioAplicacionRepositorio UsuarioAplicacion { get; private set; }
        public ISucursalRepositorio Sucursal { get; private set; }
        public IServiciosRepositorio Servicios { get; set; }
        

        public UnidadTrabajo(ApplicationDbContext db)
        {
            _db = db;
            Cliente = new ClienteRepositorio(_db); 
            Categoria = new CategoriaRepositorio(_db); 
            Empleado = new EmpleadoRepositorio(_db); 
            Producto = new ProductoRepositorio(_db); 
            UsuarioAplicacion = new UsuarioAplicacionRepositorio(_db);
            Sucursal = new SucursalRepositorio(_db);
            Servicios = new ServiciosRepositorio(_db);
        }
        public void Guardar()
        {
            _db.SaveChanges();
        }
        public void Dispose()
        {
            _db.Dispose();
        }
    }
}
