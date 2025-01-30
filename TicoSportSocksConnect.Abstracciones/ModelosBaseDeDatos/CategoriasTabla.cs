using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Categorias")]
    public class CategoriasTabla
    {
        [Key]
        public int Categoria_ID { get; set; }

        [Required, StringLength(255)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        public virtual ICollection<ProductosTabla> Productos { get; set; }
    }
}
