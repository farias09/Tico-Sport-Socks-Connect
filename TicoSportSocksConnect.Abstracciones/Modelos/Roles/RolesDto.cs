using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.Modelos.ListaOrdenes
{
    public class RolesDto
    {
        [Key]
        public int Rol_ID { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; }

        public string descripcion { get; set; }
    }
}
