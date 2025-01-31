using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    public class MovimientosCaja
    {
        [Key]
        public int MovimientoCaja_ID { get; set; }

        [Required]
        public int Caja_ID { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required, StringLength(50)]
        public string Tipo_Movimiento {  get; set; }

        [Required]
        public decimal? Monto { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public int Venta_id { get; set; }

        [Required]
        public int Usuario_ID { get; set; }

        [ForeignKey("Venta_id")]
        public virtual VentasTabla Venta { get; set; }

        [ForeignKey("Usuario_ID")]
        public virtual UsuariosTabla Usuario { get; set; }
    }
}
