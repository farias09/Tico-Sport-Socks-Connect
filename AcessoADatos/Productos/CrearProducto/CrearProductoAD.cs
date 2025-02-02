using Abstracciones.AD.Interfaces.Productos.CrearProducto;
using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Productos.CrearProducto
{
    public class CrearProductoAD : ICrearProductoAD
    {
        Contexto _elContexto;

        public CrearProductoAD()
        {
            _elContexto = new Contexto();
        }

        public async Task<int> Crear(ProductosTabla elProductoAGuardar)
        {
            try
            {
                _elContexto.ProductosTabla.Add(elProductoAGuardar);
                EntityState estado = _elContexto.Entry(elProductoAGuardar).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosGuardados = await _elContexto.SaveChangesAsync();
                return cantidadDeDatosGuardados;
            }
            catch (Exception ex)
            {
                return 0;
            }
        }
    }
}
