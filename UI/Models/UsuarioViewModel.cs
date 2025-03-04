﻿using System;

namespace UI.Models
{
    public class UsuarioViewModel
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Rol { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public string Numero { get; set; }
        public string Contraseña { get; set; }  
        public DateTime FechaRegistro { get; set; }
        public bool Estado { get; set; }
    }

}