using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicoSportSocksConnect.Abstracciones.AD.Interfaces.Inventario;
using TicoSportSocksConnect.Abstracciones.Modelos.Inventario;

namespace TicoSportsSocksConnect.AccesoADatos.Inventario
{
    public class ProductoLeerAD : IProductoLeerAD
    {
        private readonly Contexto _contexto;

        public ProductoLeerAD(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task<List<ProductosDto>> ObtenerTodosAsync()
        {
            return await _contexto.Productos
                .Select(p => new ProductosDto
                {
                    Producto_ID = p.Producto_ID,
                    nombre = p.nombre,
                    descripcion = p.descripcion,
                    precio = p.precio,
                    stock = p.stock,
                    imagen = p.imagen,
                    Categoria_ID = p.Categoria_ID
                })
                .ToListAsync();
        }

        public async Task<ProductosDto> ObtenerPorIdAsync(int id)
        {
            var producto = await _contexto.Productos.FindAsync(id);
            return new ProductosDto
            {
                Producto_ID = producto.Producto_ID,
                nombre = producto.nombre,
                descripcion = producto.descripcion,
                precio = producto.precio,
                stock = producto.stock,
                imagen = producto.imagen,
                Categoria_ID = producto.Categoria_ID
            };
        }
    }
}
