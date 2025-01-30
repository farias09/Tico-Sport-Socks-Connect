using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Usuarios")]
    public class UsuariosTabla
    {
        [Key]
        public int Usuario_ID { get; set; }

        [Required, StringLength(255)]
        public string Nombre { get; set; }

        [Required, StringLength(255)]
        public string Email { get; set; }

        [StringLength(20)]
        public string Telefono { get; set; }

        [StringLength(255)]
        public string Direccion { get; set; }

        [StringLength(100)]
        public string Provincia { get; set; }

        public int Rol_ID { get; set; }

        public bool Estado { get; set; }

        [ForeignKey("Rol_ID")]
        public virtual RolesTabla Rol { get; set; }

        public virtual ICollection<VentasTabla> Ventas { get; set; }
        public virtual ICollection<ReportesTabla> Reportes { get; set; }
    }
}
