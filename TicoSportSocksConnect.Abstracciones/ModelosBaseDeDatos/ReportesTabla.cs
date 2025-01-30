using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Reportes")]
    public class ReportesTabla
    {
        [Key]
        public int Reporte_ID { get; set; }

        [Required, StringLength(100)]
        public string TipoReporte { get; set; }

        [Required]
        public DateTime FechaGeneracion { get; set; }

        public int Usuario_ID { get; set; }

        [Required, StringLength(50)]
        public string Periodo { get; set; }

        [Required, StringLength(50)]
        public string Formato { get; set; }

        [ForeignKey("Usuario_ID")]
        public virtual UsuariosTabla Usuario { get; set; }
    }

}
