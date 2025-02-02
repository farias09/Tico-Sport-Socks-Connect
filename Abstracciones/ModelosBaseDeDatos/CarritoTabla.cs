using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("Carrito")]
    public class CarritoTabla
    {
        [Key]
        public int Carrito_ID { get; set; }
        public int Venta_ID { get; set; }
        public int Producto_ID { get; set; }
        public int cantidad {  get; set; }
        public decimal? precio_unitario { get; set; }
        public decimal? subtotal { get; set; }
    }
}
