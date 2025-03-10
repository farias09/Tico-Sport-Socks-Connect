using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicoSportSocksConnect.Abstracciones.AD.Interfaces.Inventario;
using TicoSportSocksConnect.Abstracciones.LN.Interfaces.Inventario;

namespace TicoSportSocksConnect.LN.Inventario
{
    public class ProductoEliminarLN : IProductoEliminarLN
    {
        private readonly IProductoEliminarAD _productoEliminarAD;
        private readonly IProductoLeerAD _productoLeerAD;

        public ProductoEliminarLN(
            IProductoEliminarAD productoEliminarAD,
            IProductoLeerAD productoLeerAD)
        {
            _productoEliminarAD = productoEliminarAD;
            _productoLeerAD = productoLeerAD;
        }

        public async Task EliminarAsync(int id)
        {
            if (id <= 0)
                throw new ArgumentException("El ID debe ser mayor a 0");

            // Verificar que el producto existe antes de eliminarlo
            var producto = await _productoLeerAD.ObtenerPorIdAsync(id);
            if (producto == null)
                throw new KeyNotFoundException($"No se encontró el producto con ID {id}");

            // Aquí podrías agregar lógica adicional
            // Por ejemplo, verificar si el producto está en alguna orden activa
            // o si tiene permisos para eliminarlo

            await _productoEliminarAD.EliminarAsync(id);
        }
    }
}
