using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Data.Repositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ProductoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Producto producto)
        {
            var productoDb = _db.Productos.FirstOrDefault(p => p.Id == producto.Id);
            if (productoDb != null)
            {
                if (producto.ImageUrl != null)
                {
                    productoDb.ImageUrl = producto.ImageUrl;
                }
                if (producto.PadreId == 0)
                {
                    productoDb.PadreId = null;
                }
                else
                {
                    productoDb.PadreId = producto.PadreId;
                }
                productoDb.NumeroSerie = producto.NumeroSerie;
                productoDb.Descripcion = producto.Descripcion;
                productoDb.Precio = producto.Precio;
                productoDb.Costo = producto.Costo;
                
            }
        }
    }
}
