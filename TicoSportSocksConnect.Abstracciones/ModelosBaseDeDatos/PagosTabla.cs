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
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Monto { get; set; }

        [StringLength(100)]
        public string MetodoPago { get; set; }

        [Required, StringLength(50)]
        public string Estado { get; set; }

        public string ReferenciaTransaccion { get; set; }

        public int Caja_ID { get; set; }

        [ForeignKey("Venta_ID")]
        public virtual VentasTabla Venta { get; set; }

        [ForeignKey("Caja_ID")]
        public virtual CajasTabla Caja { get; set; }
    }

}
