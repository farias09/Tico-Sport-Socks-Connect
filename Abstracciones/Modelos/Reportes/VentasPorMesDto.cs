using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Reportes
{
    public class VentasPorMesDto
    {
        public int Mes { get; set; }
        public int Anno { get; set; }
        public decimal TotalVentas { get; set; }
        public int TotalOrdenes { get; set; }
    }
}
