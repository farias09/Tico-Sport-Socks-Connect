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
        [Display(Name = "Fecha de Venta")]
        public DateTime fecha { get; set; }

        [Required]
        [Display(Name = "Subtotal de la compra")]
        public decimal? subtotal { get; set; }

        [Required]
        [Display(Name = "Total de la compra")]
        public decimal? total { get; set; }

        [Required]
        [Display(Name = "Cliente que hizo la compra")]
        public int Usuario_ID { get; set; }

        [Required]
        [Display(Name = "Caja donde se realizó la compra")]
        public int Caja_ID { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public string estado { get; set; }
    }
}
