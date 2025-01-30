using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Mensajes")]
    public class MensajesTabla
    {
        [Key]
        public int Mensaje_ID {  get; set; }

        public int emisor_ID { get; set; }
        public int receptor_ID { get; set; }

        [Required]
        public string contenido {  get; set; }

        [Required]
        public DateTime fecha { get; set; }

        [ForeignKey("emisor_ID")]
        public virtual UsuariosTabla emisor { get; set; }

        [ForeignKey("receptor_ID")]
        public virtual UsuariosTabla receptor { get; set; }

    }
}
