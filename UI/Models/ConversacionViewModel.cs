using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace UI.Models
{
    public class ConversacionViewModel
    {
        [Key] 
        public int Id { get; set; }
        public int UsuarioId { get; set; }
        public string Nombre { get; set; }
        public string Numero { get; set; }
    }
}