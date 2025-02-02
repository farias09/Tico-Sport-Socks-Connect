using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Caja
{
    public class CajasDto
    {
        [Key]
        public int Caja_ID { get; set; }

        [Required]
        public string fecha_apertura { get; set; }

        [Required]
        public string fecha_cierre { get; set; }

        [Required]
        public decimal? monto_inicial { get; set; }

        public decimal? monto_final {  get; set; }

        public decimal? total_ventas { get; set; }

        public decimal? total_gastos { get; set; }

        [Required]
        public bool estado {  get; set; }

        [Required]
        public int Usuario_ID { get; set; }
    }
}
