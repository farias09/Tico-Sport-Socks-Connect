using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("Categorias")]
    public class CategoriasTabla
    {
        [Key]
        public int Categoria_ID {  get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
    }
}
