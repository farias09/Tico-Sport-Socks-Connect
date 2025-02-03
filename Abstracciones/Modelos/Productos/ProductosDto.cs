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
        [Display(Name = "ID del Producto", Description = "Identificador único del producto")]
        public int Producto_ID { get; set; }

        [Required(ErrorMessage = "El nombre del producto es obligatorio.")]
        [Display(Name = "Nombre del Producto", Prompt = "Ingrese el nombre del producto", Description = "Nombre del Producto")]
        [MaxLength(100, ErrorMessage = "El nombre no puede exceder los 100 caracteres.")]
        public string nombre { get; set; }

        [Display(Name = "Descripción", Prompt = "Ingrese una descripción del producto", Description = "Descripción del Producto")]
        [MaxLength(500, ErrorMessage = "La descripción no puede exceder los 500 caracteres.")]
        public string descripcion { get; set; }

        [Required(ErrorMessage = "El precio es obligatorio.")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El precio debe ser mayor a 0.")]
        [Display(Name = "Precio", Prompt = "Ingrese el precio del producto", Description = "Precio del Producto")]
        public float precio { set; get; }

        [Required(ErrorMessage = "El stock es obligatorio.")]
        [Range(0, int.MaxValue, ErrorMessage = "El stock debe ser un número positivo.")]
        [Display(Name = "Stock", Prompt = "Ingrese la cantidad de stock disponible", Description = "Cantidad de Stock")]
        public int stock { get; set; }

        [Display(Name = "Imagen", Prompt = "Ingrese la URL de la imagen del producto", Description = "URL de Imagen del Producto")]
        [Url(ErrorMessage = "El formato de la URL de la imagen no es válido.")]
        public string imagen { get; set; }

        [Required(ErrorMessage = "La categoría del producto es obligatoria.")]
        [Display(Name = "Categoría", Prompt = "Seleccione la categoría del producto", Description = "Categoría del Producto")]
        public int Categoria_ID { get; set; }

        [Required(ErrorMessage = "El estado es obligatorio.")]
        [Display(Name = "Estado", Prompt = "Seleccione el estado del producto", Description = "Estado del Producto")]
        public bool Estado { get; set; }

        [Required(ErrorMessage = "El código del producto es obligatorio.")]
        [Display(Name = "Código del Producto", Prompt = "Ingrese el código del producto", Description = "Código del Producto")]
        [Range(1, int.MaxValue, ErrorMessage = "El código del producto debe ser un número positivo.")]
        public int CodigoDelProducto { get; set; }
    }
}
