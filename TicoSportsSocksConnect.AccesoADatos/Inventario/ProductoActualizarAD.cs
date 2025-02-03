using System;
using System.Threading.Tasks;
using TicoSportSocksConnect.Abstracciones.AD.Interfaces.Inventario;
using TicoSportSocksConnect.Abstracciones.Modelos.Inventario;

namespace TicoSportsSocksConnect.AccesoADatos.Inventario
{
    public class ProductoActualizarAD : IProductoActualizarAD
    {
        private readonly Contexto _contexto;

        public ProductoActualizarAD(Contexto contexto)
        {
            _contexto = contexto;
        }

        public async Task ActualizarAsync(ProductosDto producto)
        {
            var productoExistente = await _contexto.Productos.FindAsync(producto.Producto_ID);
            if (productoExistente != null)
            {
                productoExistente.nombre = producto.nombre;
                productoExistente.descripcion = producto.descripcion;
                productoExistente.precio = producto.precio;
                productoExistente.stock = producto.stock;
                productoExistente.imagen = producto.imagen;
                productoExistente.Categoria_ID = producto.Categoria_ID;

                await _contexto.SaveChangesAsync();
            }
        }
    }
}