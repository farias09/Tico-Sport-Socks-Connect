using Abstracciones.Modelos.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Ventas.CrearVenta
{
    public interface ICrearVentaLN
    {
        Task<int> Crear(VentasDto modelo);
    }
}
