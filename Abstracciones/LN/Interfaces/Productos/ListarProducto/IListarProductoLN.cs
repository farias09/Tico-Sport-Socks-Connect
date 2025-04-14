using Abstracciones.Modelos.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Productos.ListarProducto
{
    public interface IListarProductoLN
    {
        List<ProductosDto> Listar();
        List<ProductosDto> BuscarProductos(string query);
    }
}
