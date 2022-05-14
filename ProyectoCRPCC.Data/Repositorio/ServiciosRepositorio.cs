using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Data.Repositorio
{
    public class ServiciosRepositorio : Repositorio<Servicios>,
                                           IServiciosRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ServiciosRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Servicios servicios)
        {
            var serviciosDb = _db.Servicios.FirstOrDefault(b => b.Id == servicios.Id);
            if (serviciosDb != null)
            {
                if(servicios.ImageUrl != null)
                {
                    serviciosDb.ImageUrl = servicios.ImageUrl;
                }
                serviciosDb.NombreServicio = servicios.NombreServicio;
                serviciosDb.Descripcion = servicios.Descripcion;
                serviciosDb.Estado = servicios.Estado;
                serviciosDb.IdCategoria = servicios.IdCategoria;
            }
        }
    }
}
