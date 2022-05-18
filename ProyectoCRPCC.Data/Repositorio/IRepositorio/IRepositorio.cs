using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Data.Repositorio.IRepositorio
{
    public interface IRepositorio<T> where T : class
    {
        T Obtener(int id); //Devolverá un registro según su id
        T ObtenerRegistro(string nombre); //Devuelve un registro segun su nombre
        IEnumerable<T> ObtenerTodos(
            Expression<Func<T, bool>> filter = null,
            Func<IQueryable<T>, IOrderedQueryable<T>> orderBy = null,
            string IncluirPropiedades = null
            );
        T ObtenerPrimero(
           Expression<Func<T, bool>> filter = null,
           string IncluirPropiedades = null
           );
        void Agregar(T entidad);
        void Remover(int id);
        void Remover(T entidad);
        void RemoverRango(IEnumerable<T> entidad);
    }

}

