using Abstracciones.Modelos.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Ventas.ListarVenta
{
    public interface IListarVentaAD
    {
        List<VentasDto> Listar();
    }
}
