using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Auditoria")]
    public class AuditoriaTabla
    {
        [Key]
        public int Auditoria_ID { get; set; }

        [Required]
        public DateTime fecha { get; set; }

        public int Usuario_ID { get; set; }

        [Required, StringLength(100)]
        public string tabla_afectada { get; set; }

        [Required, StringLength(50)]
        public string tipo_accion { get; set; }

        [Required]
        public int registro_ID { get; set; }

        public string valor_anterior { get; set; }
        public string valor_nuevo { get; set; }
        public string descripcion { get; set; }

        [ForeignKey("Usuario_ID")]
        public virtual UsuariosTabla Usuario { get; set; }
    }
}
