using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Productos
{
    public class ProductosDto
    {
        [Key]
        public int Producto_ID { get; set; }

        [Required]
        public string nombre { get; set; }

        public string descripcion {  get; set; }

        [Required]
        public decimal? precio {  set; get; }

        [Required]
        public int stock { get; set; }

        public string imagen { get; set; }

        [Required]
        public int Categoria_ID { get; set; }

        [Required]
        public bool Estado {  get; set; }

        [Required]
        public int CodigoDelProducto { get; set; }
    }
}
