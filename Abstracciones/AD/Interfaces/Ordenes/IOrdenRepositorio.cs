using Abstracciones.Modelos.Ordenes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Ordenes
{
    public interface IOrdenRepositorio
    {
        OrdenesDto CrearOrden(OrdenesDto orden, List<DetalleOrdenesDto> detalles);
        List<OrdenesDto> ObtenerOrdenes();
        OrdenesDto ObtenerOrdenPorId(int id);
        List<DetalleOrdenesDto> ObtenerDetallesPorOrden(int ordenId);
    }
}
