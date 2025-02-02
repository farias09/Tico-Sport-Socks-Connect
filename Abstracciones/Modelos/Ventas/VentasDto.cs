using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Ventas
{
    public class VentasDto
    {
        [Key]
        public int Venta_ID { get; set; }

        [Required]
        public string fecha { get; set; }

        [Required]
        public decimal? subtotal { get; set; }

        [Required]
        public decimal? total { get; set; }

        [Required]
        public int Usuario_ID { get; set; }

        [Required]
        public int Caja_ID { get; set; }

        [Required]
        public bool estado { get; set; }
    }
}
