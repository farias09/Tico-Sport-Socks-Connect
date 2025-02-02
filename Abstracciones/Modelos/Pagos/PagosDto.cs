using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Pagos
{
    public class PagosDto
    {
        [Key]
        public int Pago_ID { get; set; }

        [Required]
        public int Venta_ID { get; set; }

        [Required]
        public string fecha { get; set; }

        [Required]
        public decimal? monto { get; set; }

        [Required]
        public string metodo_pago { get; set; }

        [Required]
        public bool estado {  get; set; }

        [Required]
        public string referencia_transaccion {  get; set; }

        [Required]
        public int Caja_ID { get; set; }
    }
}
