using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Cajas")]
    public class CajasTabla
    {
        [Key]
        public int Caja_ID { get; set; }

        [Required]
        public DateTime fecha_apertura { get; set; }

        public DateTime? fecha_cierre { get; set; }

        [Required]
        public decimal monto_inicial { get; set; }

        public decimal? monto_final { get; set; }

        public decimal? total_ventas { get; set; }

        public decimal? total_gastos { get; set; }

        [StringLength(50)]
        public string estado { get; set; }

        public int Usuario_ID { get; set; }

        [ForeignKey("Usuario_ID")]
        public virtual UsuariosTabla Usuario { get; set; }
    }

}
