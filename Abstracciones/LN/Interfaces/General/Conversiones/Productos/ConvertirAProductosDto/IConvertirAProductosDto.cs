using Abstracciones.Modelos.Productos;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.General.Conversiones.Productos.ConvertirAProductosDto
{
    public interface IConvertirAProductosDto
    {
        ProductosDto ConvertirObjetoAProductoDto(ProductosTabla elProducto);
    }
}
