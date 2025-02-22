using Abstracciones.AD.Interfaces.Productos.CambiarEstado;
using Abstracciones.LN.Interfaces.Productos.CambiarEstado;
using AcessoADatos.Productos.CambiarEstado;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Productos.CambiarEstado
{
    public class CambiarEstadoProductoLN : ICambiarEstadoProductoLN
    {
        ICambiarEstadoProductoAD _cambiarEstado;

        public CambiarEstadoProductoLN()
        {
            _cambiarEstado = new CambiarEstadoProductoAD();
        }

        public async Task<bool> CambiarEstado(int Producto_ID, bool nuevoEstado)
        {
            return await _cambiarEstado.CambiarEstado(Producto_ID, nuevoEstado);
        }
    }
}
