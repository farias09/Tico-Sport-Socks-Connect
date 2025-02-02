using Abstracciones.AD.Interfaces.Productos.CrearProducto;
using Abstracciones.LN.Interfaces.General.Conversiones.Productos.ConvertirAProductosTabla;
using Abstracciones.LN.Interfaces.Productos.CrearProducto;
using Abstracciones.Modelos.Productos;
using AcessoADatos.Productos.CrearProducto;
using LN.General.Conversiones.Productos.ProductosTablaAProductosDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Productos.CrearProducto
{
    public class CrearProductoLN : ICrearProductoLN
    {
        ICrearProductoAD _crearProductoAD;
        IConvertirAProductosTabla _convertirAProductosTabla;

        public CrearProductoLN()
        {
            _crearProductoAD = new CrearProductoAD();
            _convertirAProductosTabla = new ConvertirAProductosTabla();
        }

        public async Task<int> Crear(ProductosDto modelo)
        {
            modelo.Estado = true;
            int cantidadDeDatosGuardados = await _crearProductoAD.Crear(_convertirAProductosTabla.ConvertirObjetoAProductosTabla(modelo));
            return cantidadDeDatosGuardados;
        }
    }
}
