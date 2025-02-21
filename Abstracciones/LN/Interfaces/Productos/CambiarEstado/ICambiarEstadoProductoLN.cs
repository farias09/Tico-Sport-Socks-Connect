using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Productos.CambiarEstado
{
    public interface ICambiarEstadoProductoLN
    {
        Task<bool> CambiarEstado(int Producto_ID, bool nuevoEstado);
    }
}
