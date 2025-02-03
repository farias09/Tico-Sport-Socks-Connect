using Abstracciones.AD.Interfaces.Productos.ObtenerPorId;
using Abstracciones.LN.Interfaces.General.Conversiones.Productos.ConvertirAProductosDto;
using Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using Abstracciones.Modelos.Productos;
using Abstracciones.ModelosBaseDeDatos;
using AcessoADatos.Productos.ObtenerPorId;
using LN.General.Conversiones.Productos.ConvertirAProductosDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Productos.ObtenerPorId
{
    public class ObtenerProductoPorIdLN : IObtenerProductoPorIdLN
    {
        IObtenerProductoPorIdAD _obtenerProducto;
        IConvertirAProductosDto _convertirAProductosDto;

        public ObtenerProductoPorIdLN()
        {
            _obtenerProducto = new ObtenerProductoPorIdAD();
            _convertirAProductosDto = new ConvertirAProductosDto();
        }

        public ProductosDto Obtener(int Producto_ID)
        {
            ProductosTabla elProductoEnBD = _obtenerProducto.Obtener(Producto_ID);
            ProductosDto elProductoAMostrar = _convertirAProductosDto.ConvertirObjetoAProductoDto(elProductoEnBD);
            return elProductoAMostrar;
        }
    }
}
