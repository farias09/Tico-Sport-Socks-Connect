using Abstracciones.AD.Interfaces.Productos.ObtenerPorId;
using Abstracciones.LN.Interfaces.Productos.ObtenerPorId;
using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Productos.ObtenerPorId
{
    public class ObtenerProductoPorIdAD : IObtenerProductoPorIdAD
    {
        Contexto _elContexto;

        public ObtenerProductoPorIdAD()
        {
            _elContexto = new Contexto();
        }

        public ProductosTabla Obtener(int Producto_ID)
        {
            ProductosTabla elProductoEnBD = _elContexto.ProductosTabla
                .Where(elProducto => elProducto.Producto_ID == Producto_ID)
                .FirstOrDefault();
            return elProductoEnBD;
        }

    }
}
