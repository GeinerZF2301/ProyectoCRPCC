using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Data.Repositorio
{
    public class CategoriaRepositorio : Repositorio<Categoria>,
                                         ICategoriaRepositorio
    {
        private readonly ApplicationDbContext _db;
        public CategoriaRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Categoria categoria)
        {
            var categoriaDb = _db.Categorias.FirstOrDefault(b => b.Id == categoria.Id);
            if (categoriaDb != null)
            {
                categoriaDb.Nombre = categoria.Nombre;
                categoriaDb.Estado = categoria.Estado;
            }
        }
    }
}
