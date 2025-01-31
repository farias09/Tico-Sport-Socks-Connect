using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.Modelos.Mensajes
{
    public class MensajesDto
    {
        [Key]
        public int Mensaje_ID { get; set; }

        [Required]
        public int emisor_ID { get; set; }

        [Required]
        public int receptor_ID { get; set; }

        [Required]
        public string contenido {  get; set; }

        [Required]
        public DateTime fecha { get; set; }
    }
}
