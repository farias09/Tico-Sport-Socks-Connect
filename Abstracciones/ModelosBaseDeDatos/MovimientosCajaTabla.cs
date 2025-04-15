using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("MovimientosCaja")]
    public class MovimientosCajaTabla
    {
        [Key]
        public int MovimientoCaja_ID { get; set; }

        public int Caja_ID { get; set; }

        public DateTime Fecha { get; set; }

        public string Tipo_Movimiento { get; set; }
        public decimal Monto { get; set; }
        public string Descripcion { get; set; }
        public int? Venta_id { get; set; }
        public string Usuario_ID { get; set; }
        public bool Estado { get; set; }

    }
}
