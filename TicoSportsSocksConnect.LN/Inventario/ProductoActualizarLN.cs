using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicoSportSocksConnect.Abstracciones.AD.Interfaces.Inventario;
using TicoSportSocksConnect.Abstracciones.LN.Interfaces.Inventario;
using TicoSportSocksConnect.Abstracciones.Modelos.Inventario;

namespace TicoSportSocksConnect.LN.Inventario
{
    public class ProductoActualizarLN : IProductoActualizarLN
    {
        private readonly IProductoActualizarAD _productoActualizarAD;
        private readonly IProductoLeerAD _productoLeerAD;

        public ProductoActualizarLN(
            IProductoActualizarAD productoActualizarAD,
            IProductoLeerAD productoLeerAD)
        {
            _productoActualizarAD = productoActualizarAD;
            _productoLeerAD = productoLeerAD;
        }

        public async Task ActualizarAsync(ProductosDto producto)
        {
            // Validaciones de negocio
            if (producto.Producto_ID <= 0)
                throw new ArgumentException("ID de producto inválido");

            // Verificar que el producto existe
            var productoExistente = await _productoLeerAD.ObtenerPorIdAsync(producto.Producto_ID);
            if (productoExistente == null)
                throw new KeyNotFoundException($"No se encontró el producto con ID {producto.Producto_ID}");

            // Validaciones adicionales
            if (producto.precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0");

            if (producto.stock < 0)
                throw new ArgumentException("El stock no puede ser negativo");

            if (string.IsNullOrWhiteSpace(producto.nombre))
                throw new ArgumentException("El nombre es requerido");

            await _productoActualizarAD.ActualizarAsync(producto);
        }
    }
}
