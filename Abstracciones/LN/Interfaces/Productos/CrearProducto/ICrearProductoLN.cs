using Abstracciones.Modelos.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Productos.CrearProducto
{
    public interface ICrearProductoLN
    {
        Task<int> Crear(ProductosDto modelo);
    }
}
