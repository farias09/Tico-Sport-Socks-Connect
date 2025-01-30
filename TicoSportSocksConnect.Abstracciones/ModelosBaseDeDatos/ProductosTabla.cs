using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos
{
    [Table("Productos")]
    public class ProductosTabla
    {
        [Key]
        public int Producto_ID { get; set; }

        [Required, StringLength(255)]
        public string Nombre { get; set; }

        public string Descripcion { get; set; }

        [Required]
        public decimal Precio { get; set; }

        public int Stock { get; set; }

        [StringLength(1024)]
        public string Imagen { get; set; }

        public int Categoria_ID { get; set; }

        [ForeignKey("Categoria_ID")]
        public virtual CategoriasTabla Categoria { get; set; }
    }
}