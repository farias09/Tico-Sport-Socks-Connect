using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("Pagos")]
    public class PagosTabla
    {
        [Key]
        public int Pago_ID { get; set; }
        public int Venta_ID { get; set; }
        public DateTime fecha { get; set; }
        public decimal? monto { get; set; }
        public string metodo_pago { get; set; }
        public bool estado {  get; set; }
        public string referencia_transaccion { get; set; }
        public int Caja_ID { get; set; }
    }
}
