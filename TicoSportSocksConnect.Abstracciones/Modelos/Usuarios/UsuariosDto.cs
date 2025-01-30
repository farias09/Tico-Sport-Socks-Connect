using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.Modelos.Usuarios
{
    public class UsuariosDto
    {
        [Key]
        public int Usuario_ID { get; set; }

        [Required, StringLength(255)]
        public string nombre { get; set; }

        [Required, StringLength(255)]
        public string email { get; set; }

        [StringLength(20)]
        public string telefono { get; set; }

        [StringLength(255)]
        public string direccion { get; set; }

        [StringLength(100)]
        public string provincia { get; set; }

        public int Rol_ID { get; set; }

        public bool estado { get; set; }
    }
}