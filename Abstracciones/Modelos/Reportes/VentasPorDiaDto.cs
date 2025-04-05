using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Reportes
{
    public class VentasPorDiaDto
    {
        public DateTime Fecha { get; set; }
        public decimal TotalVentas { get; set; }
    }
}
