using Abstracciones.AD.Interfaces.Ordenes;
using Abstracciones.Modelos.Ordenes;
using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Ordenes
{
    public class OrdenRepositorio : IOrdenRepositorio
    {
        private readonly Contexto _contexto;

        public OrdenRepositorio()
        {
            _contexto = new Contexto();
        }

        public OrdenesDto CrearOrden(OrdenesDto orden, List<DetalleOrdenesDto> detalles)
        {
            var nuevaOrden = new OrdenesTabla
            {
                Usuario_ID = orden.Usuario_ID,
                FechaOrden = DateTime.Now,
                Total = orden.Total,
                Estado = "Pendiente",
                TipoVenta = orden.TipoVenta,          
                Caja_ID = orden.Caja_ID
            };

            _contexto.OrdenesTabla.Add(nuevaOrden);
            _contexto.SaveChanges();

            foreach (var detalle in detalles)
            {
                var detalleOrden = new DetalleOrdenesTabla
                {
                    Orden_ID = nuevaOrden.Orden_ID,
                    Producto_ID = detalle.Producto_ID,
                    Cantidad = detalle.Cantidad,
                    Subtotal = detalle.Subtotal
                };

                _contexto.DetalleOrdenesTabla.Add(detalleOrden);
            
                var producto = _contexto.ProductosTabla.FirstOrDefault(p => p.Producto_ID == detalle.Producto_ID);

                if (producto != null)
                {
                    producto.stock -= detalle.Cantidad;

                    if (producto.stock < 0)
                    {
                        throw new Exception($"El producto '{producto.nombre}' no tiene stock suficiente.");
                    }
                }
            }
            _contexto.SaveChanges();

            // Retornar la orden creada con su nuevo ID
            return new OrdenesDto
            {
                Orden_ID = nuevaOrden.Orden_ID,
                Usuario_ID = nuevaOrden.Usuario_ID,
                FechaOrden = nuevaOrden.FechaOrden,
                Total = nuevaOrden.Total,
                Estado = nuevaOrden.Estado
            };
        }
        public List<OrdenesDto> ObtenerOrdenes()
        {
            return _contexto.OrdenesTabla
                .Select(o => new OrdenesDto
                {
                    Orden_ID = o.Orden_ID,
                    Usuario_ID = o.Usuario_ID,
                    FechaOrden = o.FechaOrden,
                    Total = o.Total,
                    Estado = o.Estado
                }).ToList();
        }
        public OrdenesDto ObtenerOrdenPorId(int id)
        {
            return _contexto.OrdenesTabla
                .Where(o => o.Orden_ID == id)
                .Select(o => new OrdenesDto
                {
                    Orden_ID = o.Orden_ID,
                    Usuario_ID = o.Usuario_ID,
                    FechaOrden = o.FechaOrden,
                    Estado = o.Estado,

                    Total = _contexto.DetalleOrdenesTabla
                    .Where(d => d.Orden_ID == o.Orden_ID)
                    .Sum(d => d.Subtotal)
                }).FirstOrDefault();
        }
        public List<DetalleOrdenesDto> ObtenerDetallesPorOrden(int ordenId)
        {
            return _contexto.DetalleOrdenesTabla
                .Where(d => d.Orden_ID == ordenId)
                .Select(d => new DetalleOrdenesDto
                {
                    Detalle_ID = d.Detalle_ID,
                    Orden_ID = d.Orden_ID,
                    Producto_ID = d.Producto_ID,
                    Cantidad = d.Cantidad,
                    Subtotal = d.Subtotal,

                    // Obtener el nombre y precio del producto desde la tabla Productos
                    NombreProducto = _contexto.ProductosTabla
                    .Where(p => p.Producto_ID == d.Producto_ID)
                    .Select(p => p.nombre)
                    .FirstOrDefault(),

                    PrecioUnitario = (int)_contexto.ProductosTabla
                    .Where(p => p.Producto_ID == d.Producto_ID)
                    .Select(p => p.precio)
                    .FirstOrDefault()
                }).ToList();
        }
    }
}
