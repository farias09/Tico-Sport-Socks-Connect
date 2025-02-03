using Abstracciones.Modelos.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Productos.ObtenerPorId
{
    public interface IObtenerProductoPorIdLN
    {
        ProductosDto Obtener(int IdProducto);
    }
}
