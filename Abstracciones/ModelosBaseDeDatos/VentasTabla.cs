using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("Ventas")]
    public class VentasTabla
    {
        [Key]
        public int Venta_ID { get; set; }
        public DateTime fecha { get; set; }
        public decimal? subtotal { get; set; }
        public decimal? total { get; set; }
        public int Usuario_ID { get; set; }
        public int Caja_ID { get; set; }
        public bool estado { get; set; }
    }
}
