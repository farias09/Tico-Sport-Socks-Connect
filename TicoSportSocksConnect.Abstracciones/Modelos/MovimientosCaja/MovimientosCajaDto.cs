using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.Modelos.MovimientosCaja
{
    public class MovimientosCajaDto
    {
        [Key]
        public int MovimientoCaja_ID { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required, StringLength(50)]
        public string Tipo_Movimiento {  get; set; }

        [Required]
        public decimal Monto { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public int Venta_id { get; set; }

        [Required]
        public int Usuario_ID { get; set; }
    }
}
