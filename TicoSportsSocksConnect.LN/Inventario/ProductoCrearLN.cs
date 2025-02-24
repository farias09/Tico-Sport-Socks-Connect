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
    public class ProductoCrearLN : IProductoCrearLN
    {
        private readonly IProductoCrearAD _productoCrearAD;

        public ProductoCrearLN(IProductoCrearAD productoCrearAD)
        {
            _productoCrearAD = productoCrearAD;
        }

        public async Task CrearAsync(ProductosDto producto)
        {
            // Aquí puedes agregar validaciones de negocio antes de crear
            if (producto.precio <= 0)
                throw new ArgumentException("El precio debe ser mayor a 0");

            if (producto.stock < 0)
                throw new ArgumentException("El stock no puede ser negativo");

            if (string.IsNullOrWhiteSpace(producto.nombre))
                throw new ArgumentException("El nombre es requerido");

            await _productoCrearAD.CrearAsync(producto);
        }
    }
}
