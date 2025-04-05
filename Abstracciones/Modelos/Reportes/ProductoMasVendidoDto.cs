using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.Modelos.Reportes
{
    public class ProductoMasVendidoDto
    {
        public string NombreProducto { get; set; }
        public int CantidadVendida { get; set; }
        public decimal TotalGenerado { get; set; }
    }
}
