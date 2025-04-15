using System;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos.Ordenes
{
    public class OrdenesDto
    {
        [Key]
        public int Orden_ID { get; set; }
        public int Usuario_ID { get; set; }
        public DateTime FechaOrden { get; set; }
        public decimal Total { get; set; }
        public string Estado { get; set; }
        public string TipoVenta { get; set; }          
        public int? Caja_ID { get; set; }
    }
}
