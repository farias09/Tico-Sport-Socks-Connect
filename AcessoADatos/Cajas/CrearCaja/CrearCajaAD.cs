using Abstracciones.AD.Interfaces.Cajas.CrearCaja;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Data.Entity;
using System.Linq;

namespace AccesoADatos.Cajas.CrearCaja
{
    public class CrearCajaAD : ICrearCajaAD
    {
        private readonly Contexto _elContexto;

        public CrearCajaAD (Contexto contexto)
        {
            _elContexto = contexto;
        }

        public int Crear(CajasTabla laCajaAGuardar)
        {
            try
            {
                _elContexto.CajasTabla.Add(laCajaAGuardar);
                EntityState estado = _elContexto.Entry(laCajaAGuardar).State = System.Data.Entity.EntityState.Added;
                int cantidadDeDatosGuardados = _elContexto.SaveChanges();
                return cantidadDeDatosGuardados;
            }
            catch (Exception ex)
            {

                throw new Exception("Error al crear la caja en la base de datos.", ex);
            }
        }

        public bool HayCajaAbierta()
        {
            return _elContexto.CajasTabla.Any(c => c.estado == true);
        }
    }
}
