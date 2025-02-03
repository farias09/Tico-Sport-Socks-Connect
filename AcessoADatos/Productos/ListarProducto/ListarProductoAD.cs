using Abstracciones.AD.Interfaces.Productos.ListarProducto;
using Abstracciones.Modelos.Productos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Productos.ListarProductos
{
    public class ListarProductoAD : IListarProductoAD
    {
        Contexto _elContexto;

        public ListarProductoAD()
        {
            _elContexto = new Contexto();
        }

        public List<ProductosDto> Listar()
        {
            List<ProductosDto> laListaDeProductos = (from elProducto in _elContexto.ProductosTabla
                                                     select new ProductosDto
                                                     {
                                                         Producto_ID = elProducto.Producto_ID,
                                                         nombre = elProducto.nombre,
                                                         descripcion = elProducto.descripcion,
                                                         precio = (float)elProducto.precio,
                                                         stock = elProducto.stock,
                                                         imagen = elProducto.imagen,
                                                         Categoria_ID = elProducto.Categoria_ID,
                                                         Estado = elProducto.Estado,
                                                         CodigoDelProducto = elProducto.CodigoDelProducto
                                                     }).ToList();
            return laListaDeProductos;
        }
    }
}
