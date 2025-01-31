using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Roles")]
    public class RolesTabla
    {
        [Key]
        public int Rol_ID { get; set; }

        [Required, StringLength(50)]
        public string nombre { get; set; }

        public string descripcion { get; set; }

        public virtual ICollection<UsuariosTabla> Usuarios { get; set; }
    }
}