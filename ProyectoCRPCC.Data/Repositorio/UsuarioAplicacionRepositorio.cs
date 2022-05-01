using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Data.Repositorio
{
    public class UsuarioAplicacionRepositorio : Repositorio<UsuarioAplicacion>,
                                               IUsuarioAplicacionRepositorio
    {
        private readonly ApplicationDbContext _db;
        public UsuarioAplicacionRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
    }
}
