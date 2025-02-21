using Abstracciones.Modelos.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Productos.ActualizarProducto
{
    public interface IActualizarProductoLN
    {
        Task<int> Editar(ProductosDto elProductoEnVista);
    }
}
