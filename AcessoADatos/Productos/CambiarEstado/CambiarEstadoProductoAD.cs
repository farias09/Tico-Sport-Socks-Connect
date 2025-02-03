using Abstracciones.AD.Interfaces.Productos.CambiarEstado;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Productos.CambiarEstado
{
    public class CambiarEstadoProductoAD : ICambiarEstadoProductoAD
    {
        Contexto _elContexto;

        public CambiarEstadoProductoAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<bool> CambiarEstado(int Producto_ID, bool nuevoEstado)
        {
            var producto = await _elContexto.ProductosTabla.FirstOrDefaultAsync(elProducto => elProducto.Producto_ID ==  Producto_ID);

            if (producto != null)
            {
                producto.Estado = nuevoEstado;
                _elContexto.Entry(producto).State = EntityState.Modified;
                await _elContexto.SaveChangesAsync();
                return true;
            }
            return false;
        }
    }
}
