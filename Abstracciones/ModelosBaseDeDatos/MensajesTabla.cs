using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("Mensajes")]
    public class MensajesTabla
    {
        [Key]
        public int Mensaje_ID { get; set; }
        public int emisor_ID { get; set; }
        public int receptor_ID { get; set; }
        public string contenido { get; set; }
        public DateTime fecha { get; set; }
    }
}
