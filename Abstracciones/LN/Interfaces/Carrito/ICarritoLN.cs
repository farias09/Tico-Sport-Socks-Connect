using Abstracciones.Modelos.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Carrito
{
    public interface ICarritoLN
    {
        void AgregarProductoAlCarrito(CarritoDto carrito);
        IEnumerable<CarritoDto> ObtenerProductos(int ventaId);
        decimal CalcularTotalCarrito(int ventaId);
        void EliminarProducto(int carritoId);
    }
}
