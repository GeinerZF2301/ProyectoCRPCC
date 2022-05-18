using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Data.Repositorio
{
    public class SucursalRepositorio : Repositorio<Sucursal>,
                                         ISucursalRepositorio
    {
        private readonly ApplicationDbContext _db;
        public SucursalRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Sucursal sucursal)
        {
            var sucursalDb = _db.Sucursales.FirstOrDefault(b => b.Id == sucursal.Id);
            if (sucursalDb != null)
            {
                sucursalDb.Nombre = sucursal.Nombre;
                sucursalDb.Direccion = sucursal.Direccion;
                sucursalDb.Estado = sucursal.Estado;
            }
        }
    }
}