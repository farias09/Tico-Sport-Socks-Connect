using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Reportes
{
    public class ReportesDto
    {
        [Key]
        public int Reporte_ID { get; set; }

        [Required]
        public string tipo_reporte { get; set; }

        [Required]
        public string fecha_generacion { get; set; }

        [Required]
        public int Usuario_ID { get; set; }

        [Required]
        public string periodo { get; set; }

        [Required]
        public string formato { get; set; }
    }
}
