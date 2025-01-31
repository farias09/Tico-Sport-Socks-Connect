using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.Modelos.Ventas
{
    public class VentasDto
    {
        [Key]
        public int Venta_ID { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [Required]
        public decimal subtotal { get; set; }

        [Required]
        public decimal total { get; set; }

        public int Usuario_ID { get; set; }
        public int Caja_ID { get; set; }

        [StringLength(50)]
        public string estado { get; set; }
    }
}