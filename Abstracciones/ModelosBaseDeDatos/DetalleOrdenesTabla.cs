using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    public class DetalleOrdenesTabla
    {
        [Key]
        public int Detalle_ID { get; set; }
        public int Orden_ID { get; set; }
        public int Producto_ID { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public string NombreProducto { get; set; } 
        public int PrecioUnitario { get; set; } 

    }
}
