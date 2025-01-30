using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Carrito")]
    public class CarritoTabla
    {
        [Key]
        public int Carrito_ID { get; set; }

        public int Venta_ID { get; set; }
        public int Producto_ID { get; set; }

        public int Cantidad { get; set; }

        [Required]
        public decimal PrecioUnitario { get; set; }

        [Required]
        public decimal Subtotal { get; set; }

        [ForeignKey("Venta_ID")]
        public virtual VentasTabla Venta { get; set; }

        [ForeignKey("Producto_ID")]
        public virtual ProductosTabla Producto { get; set; }
    }

}
