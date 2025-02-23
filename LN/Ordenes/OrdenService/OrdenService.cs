using Abstracciones.AD.Interfaces.Ordenes;
using Abstracciones.Modelos.Ordenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
