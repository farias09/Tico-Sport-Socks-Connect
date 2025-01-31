using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Pagos")]
    public class PagosTabla
    {
        [Key]
        public int Pago_ID { get; set; }

        public int Venta_ID { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public decimal monto { get; set; }

        [StringLength(100)]
        public string metodo_pago { get; set; }

        [Required, StringLength(50)]
        public string estado { get; set; }

        public string referencia_transaccion { get; set; }

        public int Caja_ID { get; set; }

        [ForeignKey("Venta_ID")]
        public virtual VentasTabla Venta { get; set; }

        [ForeignKey("Caja_ID")]
        public virtual CajasTabla Caja { get; set; }
    }

}
