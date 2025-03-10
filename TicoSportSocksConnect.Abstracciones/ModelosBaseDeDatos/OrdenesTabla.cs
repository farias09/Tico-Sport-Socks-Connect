using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Ordenes")]
    public class OrdenesTabla
    {
        [Key] // Marca esta propiedad como clave primaria
        public int Orden_ID { get; set; } // Asegúrate de que esta propiedad exista

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Total { get; set; }

        [Required]
        public int Cliente_ID { get; set; }

        [ForeignKey("Cliente_ID")]
        public virtual ClientesTabla Cliente { get; set; }

        // Otras propiedades...
    }
}