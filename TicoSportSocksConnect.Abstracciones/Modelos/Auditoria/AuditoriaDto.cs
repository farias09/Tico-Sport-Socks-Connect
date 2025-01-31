using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.Modelos.Auditoria
{
    public class AuditoriaDto
    {
        [Key]
        public int Auditoria_ID { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        public int Usuario_ID { get; set; }

        [Required, StringLength(100)]
        public string tabla_afectada { get; set; }

        [Required, StringLength(50)]
        public string tipo_accion { get; set; }

        [Required]
        public int Registro_ID { get; set; }

        public string valor_anterior { get; set; }
        public string valor_nuevo { get; set; }
        public string descripcion { get; set; }
    }
}