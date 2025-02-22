using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("Reportes")]
    public class ReportesTabla
    {
        [Key]
        public int Reporte_ID { get; set; }
        public string tipo_reporte { get; set; }
        public DateTime fecha_generacion { get; set; }
        public int Usuario_ID { get; set; }
        public string periodo {  get; set; }
        public string formato { get; set; }
    }
}
