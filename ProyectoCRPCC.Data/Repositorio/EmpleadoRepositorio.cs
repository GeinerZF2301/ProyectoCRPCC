using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Data.Repositorio
{
    public class EmpleadoRepositorio : Repositorio<Empleado>,
                                          IEmpleadoRepositorio
    {
        private readonly ApplicationDbContext _db;
        public EmpleadoRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Empleado empleado)
        {
            var empleadoDb = _db.Empleado.FirstOrDefault(b => b.Id == empleado.Id);
            if (empleadoDb != null)
            {
                empleadoDb.Nombre = empleado.Nombre;
                empleadoDb.Apellido1 = empleado.Apellido1;
                empleadoDb.Apellido2 = empleado.Apellido2;
                empleadoDb.Cedula = empleado.Cedula;
                empleadoDb.Direccion = empleado.Direccion;
                empleadoDb.Email = empleado.Email;
                empleadoDb.NumeroTelefono = empleado.NumeroTelefono;
                empleadoDb.SucursalId = empleado.SucursalId;
            }
        }
    }
}

