using Abstracciones.AD.Interfaces.Productos.ActualizarProducto;
using Abstracciones.LN.Interfaces.General.Conversiones.Productos.ConvertirAProductosTabla;
using Abstracciones.LN.Interfaces.Productos.ActualizarProducto;
using Abstracciones.Modelos.Productos;
using AcessoADatos.Productos.ActualizarProducto;
using LN.General.Conversiones.Productos.ProductosTablaAProductosDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Productos.ActualizarProducto
{
    public class ActualizarProductoLN : IActualizarProductoLN
    {
        IActualizarProductoAD _actualizarProductoAD;
        IConvertirAProductosTabla _convertirAProductosTabla;

        public ActualizarProductoLN()
        {
            _actualizarProductoAD = new ActualizarProductoAD();
            _convertirAProductosTabla = new ConvertirAProductosTabla();
        }

        public async Task<int> Editar(ProductosDto elProductoEnVista)
        {
            int cantidadDeDatosActualizados = await _actualizarProductoAD.Editar(_convertirAProductosTabla.ConvertirObjetoAProductosTabla(elProductoEnVista));
            return cantidadDeDatosActualizados;
        }
    }
}
