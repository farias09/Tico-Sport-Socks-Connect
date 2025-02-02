using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Categorias
{
    public class CategoriasDto
    {
        [Key]
        public int Categoria_ID { get; set; }

        [Required]
        public string nombre { get; set; }

        public string descripcion {  get; set; }
    }
}
