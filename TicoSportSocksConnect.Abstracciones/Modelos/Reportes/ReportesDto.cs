using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.Modelos.Reportes
{
    public class ReportesDto
    {
        [Key]
        public int Reporte_ID { get; set; }

        [Required, StringLength(100)]
        public string tipo_reporte { get; set; }

        [Required]
        public DateTime fecha_generacion { get; set; }

        public int Usuario_ID { get; set; }

        [Required, StringLength(50)]
        public string periodo { get; set; }

        [Required, StringLength(50)]
        public string formato { get; set; }
    }
}