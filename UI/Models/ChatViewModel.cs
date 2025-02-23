using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace UI.Models
{
    public class ChatViewModel
    {
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Numero { get; set; }
        public List<MensajeViewModel> Mensajes { get; set; }
    }

    public class MensajeViewModel
    {
        public string Contenido { get; set; }
        public DateTime Fecha { get; set; }
        public bool EsMio { get; set; } 
    }
}