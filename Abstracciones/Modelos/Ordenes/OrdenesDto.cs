using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
