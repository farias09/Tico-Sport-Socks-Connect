using Abstracciones.LN.Interfaces.General.Conversiones.Productos.ConvertirAProductosDto;
using Abstracciones.Modelos.Productos;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.General.Conversiones.Productos.ConvertirAProductosDto
{
    public class ConvertirAProductosDto : IConvertirAProductosDto
    {
        public ProductosDto ConvertirObjetoAProductoDto(ProductosTabla elProducto)
        {
            return new ProductosDto
            {
                Producto_ID = elProducto.Producto_ID,
                nombre = elProducto.nombre,
                descripcion = elProducto.descripcion,
                precio = elProducto.precio, 
                stock = elProducto.stock,
                imagen = elProducto.imagen,
                CodigoDelProducto = elProducto.CodigoDelProducto,
                Estado = elProducto.Estado,
                Categoria_ID = elProducto.Categoria_ID
            };
        }
    }
}
