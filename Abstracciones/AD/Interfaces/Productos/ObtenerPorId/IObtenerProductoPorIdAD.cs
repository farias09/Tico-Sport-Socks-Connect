using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Productos.ObtenerPorId
{
    public interface IObtenerProductoPorIdAD
    {
        ProductosTabla Obtener(int IdProducto);
    }
}
