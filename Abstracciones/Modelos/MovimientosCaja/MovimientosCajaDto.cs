using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.MovimientosCaja
{
    public class MovimientosCajaDto
    {
        [Key]
        public int MovimientoCaja_ID { get; set; }

        public int Caja_ID { get; set; }

        public DateTime Fecha { get; set; }

        [Required]
        public string Tipo_Movimiento { get; set; }

        [Required]
        public decimal Monto { get; set; }

        public string Descripcion { get; set; }

        public int? Venta_id { get; set; }

        public string Usuario_ID { get; set; }

        public bool Estado { get; set; }
    }
}
