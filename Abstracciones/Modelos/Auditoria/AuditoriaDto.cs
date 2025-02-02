using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Auditoria
{
    public class AuditoriaDto
    {
        [Key]
        public int Auditoria_ID { get; set; }

        [Required]
        public string fecha { get; set; }

        [Required]
        public int Usuario_ID { get; set; }

        [Required]
        public string tabla_afectada { get; set; }

        [Required]
        public string tipo_accion {  get; set; }

        [Required]
        public int registro_ID { get; set; }

        public string valor_anterior { get; set; }

        public string valor_nuevo { get; set; }

        public string descripcion { get; set; }
    }
}
