using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ProyectoCRPCC.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProyectoCRPCC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Empleado> Empleado { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Servicios> Servicios { get; set; }
        public DbSet<Producto> Productos { get; set; }
        public DbSet<Sucursal> Sucursales { get; set; }
        public DbSet<ServicioDetalle> ServicioDetalles { get; set; }
        public DbSet<ServiciosCliente> ServiciosClientes{ get; set; }
        public DbSet<ServiciosClienteDetalle> ServiciosClienteDetalles { get; set; }
        public DbSet<UsuarioAplicacion> UsuarioAplicacion { get; set; }




    }
}
