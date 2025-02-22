using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Productos.CambiarEstado
{
    public interface ICambiarEstadoProductoAD
    {
        Task<bool> CambiarEstado(int Producto_ID, bool nuevoEstado);
    }
}
