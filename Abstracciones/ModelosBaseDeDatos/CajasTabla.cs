using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("Cajas")]
    public class CajasTabla
    {
        [Key]
        public int Caja_ID { get; set; }
        public string nombre_caja { get; set; } 

        public DateTime fecha_apertura { get; set; }
        public DateTime? fecha_cierre { get; set; }
        public decimal? monto_inicial { get; set; }
        public decimal? monto_final {  get; set; }
        public decimal? total_ventas { get; set; }
        public decimal? total_gastos { get; set; }
        public string estado {  get; set; }
        public int Usuario_ID { get; set; }
    }
}
