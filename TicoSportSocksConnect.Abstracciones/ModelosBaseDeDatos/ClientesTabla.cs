using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Clientes")]
    public class ClientesTabla
    {
        [Key] // Marca esta propiedad como clave primaria
        public int Cliente_ID { get; set; } // Asegúrate de que esta propiedad exista

        [Required, StringLength(255)]
        public string Nombre { get; set; }

        [StringLength(255)]
        public string Apellido { get; set; }

        [Required, StringLength(255)]
        public string Correo { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        // Otras propiedades...
    }
}