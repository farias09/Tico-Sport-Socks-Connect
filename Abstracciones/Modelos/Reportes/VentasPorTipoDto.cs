using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Reportes
{
    public class VentasPorTipoDto
    {
        public string TipoVenta { get; set; }
        public int CantidadOrdenes { get; set; }
        public decimal TotalVentas { get; set; }
    }
}
