using Abstracciones.AD.Interfaces.Cajas.CrearCaja;
using Abstracciones.ModelosBaseDeDatos;
using System.Linq;
using System;

namespace AccesoADatos.Cajas.CrearCaja
{
    public class CrearCajaAD : ICrearCajaAD
    {
        private readonly Contexto _contexto;

        public CrearCajaAD(Contexto contexto)
        {
            _contexto = contexto;
        }

        public int Crear(CajasTabla laCajaAGuardar)
        {
            try
            {
                _contexto.CajasTabla.Add(laCajaAGuardar);
                return _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                throw new Exception($"Error al crear la caja en la base de datos. Usuario_GUID: {laCajaAGuardar.Usuario_GUID}", ex);
            }
        }

        public bool HayCajaAbierta()
        {
            return _contexto.CajasTabla.Any(c => c.estado == true);
        }

    }
}
