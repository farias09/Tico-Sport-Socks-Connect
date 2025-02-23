using Abstracciones.AD.Interfaces;
using Abstracciones.LN.Interfaces.Carrito;
using Abstracciones.Modelos.Carrito;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Carrito
{
    public class CarritoLN : ICarritoLN
    {
        private readonly ICarritoRepository _carritoRepository;

        public CarritoLN(ICarritoRepository carritoRepository)
        {
            _carritoRepository = carritoRepository;
        }

        public void AgregarProductoAlCarrito(CarritoDto carrito)
        {
            _carritoRepository.AgregarProducto(carrito);
        }

        public IEnumerable<CarritoDto> ObtenerProductos(int ventaId)
        {
            return _carritoRepository.ObtenerProductosPorVenta(ventaId);
        }

        public decimal CalcularTotalCarrito(int ventaId)
        {
            return _carritoRepository.CalcularTotal(ventaId);
        }

        public void EliminarProducto(int carritoId)
        {
            _carritoRepository.EliminarProductoDelCarrito(carritoId);
        }
    }
}
