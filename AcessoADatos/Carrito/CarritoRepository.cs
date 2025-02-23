using Abstracciones.AD.Interfaces;
using Abstracciones.Modelos.Carrito;
using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Carrito
{
    public class CarritoRepository : ICarritoRepository
    {
        private readonly Contexto _contexto;

        public CarritoRepository(Contexto contexto)
        {
            contexto = _contexto;
        }

        public void AgregarProducto(CarritoDto carrito)
        {
            var carritoEntity = new CarritoTabla
            {
                Venta_ID = carrito.Venta_ID,
                Producto_ID = carrito.Producto_ID,
                cantidad = carrito.cantidad,
                precio_unitario = carrito.precio_unitario,
                subtotal = carrito.subtotal,
            };

            _contexto.CarritoTabla.Add(carritoEntity);
            _contexto.SaveChanges();
        }

        public IEnumerable<CarritoDto> ObtenerProductosPorVenta(int ventaId)
        {
            return _contexto.CarritoTabla
                .Where(c => c.Venta_ID == ventaId)
                .Select(c => new CarritoDto
                {
                    Carrito_ID = c.Carrito_ID,
                    Venta_ID = c.Venta_ID,
                    Producto_ID = c.Producto_ID,
                    cantidad = c.cantidad,
                    precio_unitario = c.precio_unitario,
                    subtotal = c.subtotal,
                })
                .ToList();
        }

        public void EliminarProductoDelCarrito(int carritoId)
        {
            var item = _contexto.CarritoTabla.Find(carritoId);
            if (item != null)
            {
                _contexto.CarritoTabla.Remove(item);
                _contexto.SaveChanges();
            }
        }

        public decimal CalcularTotal(int ventaId)
        {
            return _contexto.CarritoTabla
                             .Where(c => c.Venta_ID == ventaId)
                             .Sum(c => c.subtotal) ?? 0;
        }
    }
}
