using ProyectoCRPCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Data.Repositorio.IRepositorio
{
    public interface ISucursalRepositorio : IRepositorio<Sucursal>
    {
        void Actualizar(Sucursal sucursal);
    }
}