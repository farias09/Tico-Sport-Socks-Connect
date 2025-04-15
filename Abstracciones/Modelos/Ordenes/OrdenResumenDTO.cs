using System;
using System.Collections.Generic;

namespace Abstracciones.Modelos.Ordenes
{
    public class OrdenResumenDto
    {
        public int Orden_ID { get; set; }
        public string UsuarioNombre { get; set; }
        public DateTime FechaOrden { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public string TipoVenta { get; set; } 
        public string NombreCaja { get; set; } 
        public List<DetalleOrdenResumenDto> Detalles { get; set; }
    }

    public class DetalleOrdenResumenDto
    {
        public string NombreProducto { get; set; }
        public int Cantidad { get; set; }
        public decimal PrecioUnitario { get; set; }
        public decimal Subtotal { get; set; }
    }
}
