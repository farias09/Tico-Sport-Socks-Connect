using Abstracciones.Modelos.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Ventas.ListarVenta
{
    public interface IListarVentaLN
    {
        List<VentasDto> Listar();
    }
}
