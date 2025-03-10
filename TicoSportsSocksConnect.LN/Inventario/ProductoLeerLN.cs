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
    public class ProductoLeerLN : IProductoLeerLN
    {
        private readonly IProductoLeerAD _productoLeerAD;

        public ProductoLeerLN(IProductoLeerAD productoLeerAD)
        {
            _productoLeerAD = productoLeerAD;
        }

        public async Task<List<ProductosDto>> ObtenerTodosAsync()
        {
            // Aquí puedes agregar lógica adicional antes de obtener los productos
            return await _productoLeerAD.ObtenerTodosAsync();
        }

        public async Task<ProductosDto> ObtenerPorIdAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0");

            var producto = await _productoLeerAD.ObtenerPorIdAsync(id);

            if (producto == null)
                throw new KeyNotFoundException($"No se encontró el producto con ID {id}");

            return producto;
        }
    }
}
