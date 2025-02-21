using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.ModelosBaseDeDatos
{
    [Table("Productos")]
    public class ProductosTabla
    {
        [Key]
        public int Producto_ID { get; set; }
        public string nombre { get; set; }
        public string descripcion { get; set; }
        public double precio { get; set; }
        public int stock { get; set; }
        public string imagen { get; set; }
        public int Categoria_ID { get; set; }
        public bool Estado { get; set; }
        public int CodigoDelProducto { get; set; }
    }
}
