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
        public DateTime FechaApertura { get; set; }

        public DateTime? FechaCierre { get; set; }

        [Required]
        public decimal MontoInicial { get; set; }

        public decimal? MontoFinal { get; set; }

        public decimal? TotalVentas { get; set; }

        public decimal? TotalGastos { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        public int Usuario_ID { get; set; }

        [ForeignKey("Usuario_ID")]
        public virtual UsuariosTabla Usuario { get; set; }
    }

}
