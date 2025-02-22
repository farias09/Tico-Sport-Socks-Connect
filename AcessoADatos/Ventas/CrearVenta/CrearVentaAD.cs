using Abstracciones.AD.Interfaces.Ventas.CrearVenta;
using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Ventas.CrearVenta
{
    public class CrearVentaAD : ICrearVentaAD
    {
        private readonly Contexto _elContexto;

        public CrearVentaAD(Contexto contexto)
        {
            _elContexto = contexto;
        }

        public async Task<int> Crear(VentasTabla laVentaAGuardar)
        {
            try
            {
                _elContexto.VentasTabla.Add(laVentaAGuardar);
                EntityState estado = _elContexto.Entry(laVentaAGuardar).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosGuardados = _elContexto.SaveChanges();
                return cantidadDeDatosGuardados;
            }
            catch (Exception ex) 
            {
                throw new Exception("Error al crear la venta en la base de datos.", ex);
            }
        }
    }
}
