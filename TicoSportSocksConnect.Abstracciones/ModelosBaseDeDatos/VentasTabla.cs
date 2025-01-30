using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Ventas")]
    public class VentasTabla
    {
        [Key]
        public int Venta_ID { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public decimal Subtotal { get; set; }

        [Required]
        public decimal Total { get; set; }

        public int Usuario_ID { get; set; }
        public int Caja_ID { get; set; }

        [StringLength(50)]
        public string Estado { get; set; }

        [ForeignKey("Usuario_ID")]
        public virtual UsuariosTabla Usuario { get; set; }

        [ForeignKey("Caja_ID")]
        public virtual CajasTabla Caja { get; set; }

        public virtual ICollection<CarritoTabla> Carrito { get; set; }
    }

}
