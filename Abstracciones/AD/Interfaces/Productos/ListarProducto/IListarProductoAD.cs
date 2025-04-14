using Abstracciones.Modelos.Productos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Productos.ListarProducto
{
    public interface IListarProductoAD
    {
        List<ProductosDto> Listar();

        List<ProductosDto> BuscarProductos(string query);
    }
}
