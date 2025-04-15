using System;
using System.ComponentModel.DataAnnotations;

namespace Abstracciones.Modelos.Caja
{
    public class CajasDto
    {
        [Key]
        public int Caja_ID { get; set; }

        [Required(ErrorMessage = "El nombre de la caja es obligatorio.")]
        [StringLength(100)]
        public string nombre_caja { get; set; }

        [Required]
        public DateTime fecha_apertura { get; set; }

        public DateTime? fecha_cierre { get; set; }

        [Required(ErrorMessage = "El monto inicial es obligatorio.")]
        public decimal monto_inicial { get; set; }

        public decimal? monto_final { get; set; }

        public decimal? total_ventas { get; set; }

        public decimal? total_gastos { get; set; }

        [Required]
        public bool estado { get; set; }

        [StringLength(128)]
        [Required(ErrorMessage = "El ID del usuario es obligatorio.")]
        public string Usuario_ID { get; set; }
    }
}
