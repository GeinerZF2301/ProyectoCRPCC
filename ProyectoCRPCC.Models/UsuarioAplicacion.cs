﻿using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoCRPCC.Models
{
    public class UsuarioAplicacion : IdentityUser
    {
        [Required]
        public string Nombres { get; set; }
        [Required]
        public string Apellidos { get; set; }
        public string Direccion { get; set; }
        public string Ciudad { get; set; }
        public string Pais { get; set; }
        public string Telefono { get; set; }
        [NotMapped]
        public string Role { get; set; }




    }
}
