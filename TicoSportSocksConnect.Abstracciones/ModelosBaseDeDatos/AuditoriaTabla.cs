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
        public DateTime Fecha { get; set; }

        public int Usuario_ID { get; set; }

        [Required, StringLength(100)]
        public string TablaAfectada { get; set; }

        [Required, StringLength(50)]
        public string TipoAccion { get; set; }

        [Required]
        public int Registro_ID { get; set; }

        public string ValorAnterior { get; set; }
        public string ValorNuevo { get; set; }
        public string Descripcion { get; set; }

        // Relación con Usuarios
        [ForeignKey("Usuario_ID")]
        public virtual UsuariosTabla Usuario { get; set; }
    }
}
