using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("Auditoria")]
    public class AuditoriaTabla
    {
        [Key]
        public int Auditoria_ID { get; set; }
        public DateTime fecha { get; set; }
        public int Usuario_ID {  get; set; }
        public string tabla_afectada { get; set; }
        public int registro_ID { get; set; }
        public string valor_anterior { get; set; }
        public string valor_nuevo { get; set; }
        public string descripcion { get; set; }

    }
}
