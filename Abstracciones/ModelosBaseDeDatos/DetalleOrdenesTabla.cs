using System.ComponentModel.DataAnnotations;

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
