using Abstracciones.AD.Interfaces.MoviemientosCaja;
using Abstracciones.ModelosBaseDeDatos;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos.MovimientosCajas.CrearMovimiento
{
    public class CrearMovimientoAD : ICrearMovimientoAD
    {
        private readonly Contexto _elContexto;

        public CrearMovimientoAD(Contexto contexto)
        {
            _elContexto = contexto;
        }

        public async Task<int> Guardar(MovimientosCajaTabla elMovimientoAGuardar)
        {
            try
            {
                _elContexto.MovimientosCajaTabla.Add(elMovimientoAGuardar);
                EntityState estado = _elContexto.Entry(elMovimientoAGuardar).State = System.Data.Entity.EntityState.Added;
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
