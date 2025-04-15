using Abstracciones.AD.Interfaces.Ordenes;
using Abstracciones.Modelos.Ordenes;
using Abstracciones.Modelos.Reportes;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LN.Ordenes.OrdenService
{
    public class OrdenService
    {
        private readonly IOrdenRepositorio _ordenRepositorio;

        public OrdenService(IOrdenRepositorio ordenRepositorio)
        {
            _ordenRepositorio = ordenRepositorio;
        }

        public OrdenesDto CrearOrden(OrdenesDto orden, List<DetalleOrdenesDto> detalles)
        {
            return _ordenRepositorio.CrearOrden(orden, detalles);
        }

        public List<OrdenesDto> ObtenerOrdenes()
        {
            return _ordenRepositorio.ObtenerOrdenes();
        }

        public OrdenesDto ObtenerOrdenPorId(int id)
        {
            return _ordenRepositorio.ObtenerOrdenPorId(id);
        }

        public List<DetalleOrdenesDto> ObtenerDetallesPorOrden(int ordenId)
        {
            return _ordenRepositorio.ObtenerDetallesPorOrden(ordenId);
        }

        public List<OrdenResumenDto> ObtenerUltimasOrdenesConDetalles(
        Func<int, string> obtenerNombreUsuario,
        Func<int?, string> obtenerNombreCaja) 
        {
            var ultimasOrdenes = _ordenRepositorio.ObtenerOrdenes()
                .OrderByDescending(o => o.FechaOrden)
                .Take(5)
                .ToList();

            var resultado = new List<OrdenResumenDto>();

            foreach (var orden in ultimasOrdenes)
            {
                var detalles = _ordenRepositorio.ObtenerDetallesPorOrden(orden.Orden_ID);
                var resumenDetalles = detalles.Select(d => new DetalleOrdenResumenDto
                {
                    NombreProducto = d.NombreProducto ?? "Producto sin nombre",
                    Cantidad = d.Cantidad,
                    PrecioUnitario = d.PrecioUnitario,
                    Subtotal = d.Subtotal
                }).ToList();

                var dto = new OrdenResumenDto
                {
                    Orden_ID = orden.Orden_ID,
                    UsuarioNombre = obtenerNombreUsuario(orden.Usuario_ID),
                    FechaOrden = orden.FechaOrden,
                    Total = orden.Total,
                    Estado = orden.Estado,
                    TipoVenta = orden.TipoVenta,
                    NombreCaja = obtenerNombreCaja(orden.Caja_ID),
                    Detalles = resumenDetalles
                };

                resultado.Add(dto);
            }

            return resultado;
        }

        public List<VentasPorDiaDto> ObtenerVentasPorDia(DateTime? fechaInicio, DateTime? fechaFin)
        {
            return _ordenRepositorio.ObtenerVentasPorDia(fechaInicio, fechaFin);
        }

        public List<VentasPorUsuarioDto> ObtenerVentasPorUsuario()
        {
            return _ordenRepositorio.ObtenerVentasPorUsuario();
        }

        public List<ProductoMasVendidoDto> ObtenerProductosMasVendidos()
        {
            return _ordenRepositorio.ObtenerProductosMasVendidos();
        }

        public List<VentasPorTipoDto> ObtenerVentasPorTipo()
        {
            return _ordenRepositorio.ObtenerVentasPorTipo();
        }

        public List<VentasPorMesDto> ObtenerVentasPorMes()
        {
            return _ordenRepositorio.ObtenerVentasPorMes();
        }

        public List<OrdenesDto> BuscarOrdenes(string query)
        {
            return _ordenRepositorio.BuscarOrdenes(query);
        }
    }
}
