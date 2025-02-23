using Abstracciones.Modelos.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces
{
    public interface ICarritoRepository
    {
        void AgregarProducto(CarritoDto carrito);

        IEnumerable<CarritoDto> ObtenerProductosPorVenta(int ventaId);

        void EliminarProductoDelCarrito(int carritoId);

        decimal CalcularTotal(int ventaId);
    }
}
