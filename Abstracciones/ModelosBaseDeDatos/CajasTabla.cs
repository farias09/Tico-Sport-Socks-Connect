using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("Cajas")]
    public class CajasTabla
    {
        [Key]
        public int Caja_ID { get; set; }

        [Column(TypeName = "varchar")]
        [StringLength(100)]
        public string nombre_caja { get; set; }

        [Required]
        public DateTime fecha_apertura { get; set; }

        public DateTime? fecha_cierre { get; set; }

        [Required]
        public decimal monto_inicial { get; set; }

        public decimal? monto_final { get; set; }

        public decimal? total_ventas { get; set; }

        public decimal? total_gastos { get; set; }

        [Required]
        public bool estado { get; set; }

        [Required]
        public string Usuario_GUID { get; set; }
    }
}
