using ProyectoCRPCC.Data.Repositorio.IRepositorio;
using ProyectoCRPCC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Data.Repositorio
{
    public class ClienteRepositorio : Repositorio<Cliente>,
                                         IClienteRepositorio
    {
        private readonly ApplicationDbContext _db;
        public ClienteRepositorio(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }
        public void Actualizar(Cliente cliente)
        {
            var clienteDb = _db.Clientes.FirstOrDefault(b => b.Id == cliente.Id);
            if (clienteDb != null){

                if (cliente.ImageUrl != null)
                {
                    clienteDb.ImageUrl = cliente.ImageUrl;
                }
                clienteDb.NombreCliente = cliente.NombreCliente;
                clienteDb.Apellido1 = cliente.Apellido1;
                clienteDb.Apellido2 = cliente.Apellido2;
                clienteDb.Cedula= cliente.Cedula;
                clienteDb.ServicioId = cliente.ServicioId;
                clienteDb.Direccion = cliente.Direccion;
                clienteDb.CodigoPostal = cliente.CodigoPostal;
                clienteDb.Email = cliente.Email;
                clienteDb.NumeroTelefono  = cliente.NumeroTelefono;
               
            }
        }
    }
}
