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
                                                         precio = elProducto.precio,
                                                         stock = elProducto.stock,
                                                         imagen = elProducto.imagen,
                                                         Categoria_ID = elProducto.Categoria_ID,
                                                         Estado = elProducto.Estado,
                                                         CodigoDelProducto = elProducto.CodigoDelProducto
                                                     }).ToList();
            return laListaDeProductos;
        }

        public List<ProductosDto> BuscarProductos(string query)
        {
            return _elContexto.ProductosTabla
                .Where(p => p.nombre.Contains(query) ||
                           p.descripcion.Contains(query) ||
                           p.CodigoDelProducto.ToString().Contains(query))
                .Select(p => new ProductosDto
                {
                    Producto_ID = p.Producto_ID,
                    nombre = p.nombre,
                    descripcion = p.descripcion,
                    precio = p.precio,
                    stock = p.stock,
                    imagen = p.imagen,
                    Categoria_ID = p.Categoria_ID,
                    Estado = p.Estado,
                    CodigoDelProducto = p.CodigoDelProducto
                })
                .ToList();
        }
    }
}
