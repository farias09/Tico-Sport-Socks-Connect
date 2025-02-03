using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("Usuarios")]
    public class UsuariosTabla
    {
        [Key]
        public int Usuario_ID { get; set; }
        public string Nombre { get; set; }
        public string Email { get; set; }
        public string Telefono { get; set; }
        public string Direccion { get; set; }
        public string Provincia { get; set; }
        public int Rol_ID { get; set; }
        public bool estado { get; set; }
    }
}
