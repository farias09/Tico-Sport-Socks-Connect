using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.Modelos.Carrito
{
    public class CarritoDto
    {
        [Key]
        public int Carrito_ID { get; set; }

        public int Venta_ID { get; set; }
        public int Producto_ID { get; set; }

        public int cantidad { get; set; }

        [Required]
        public decimal precio_unitario { get; set; }

        [Required]
        public decimal subtotal { get; set; }
    }
}