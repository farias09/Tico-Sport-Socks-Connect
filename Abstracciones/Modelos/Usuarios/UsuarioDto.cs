using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Usuarios
{
    public class UsuarioDto
    {
        public int Usuario_ID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public int Rol { get; set; }
        public bool estado { get; set; }
    }
}
