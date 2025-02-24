using Abstracciones.AD.Interfaces.Cajas.CrearCaja;
using Abstracciones.LN.Interfaces.Cajas.CrearCaja;
using Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosTabla;
using Abstracciones.Modelos.Caja;

namespace LN.Cajas.CrearCaja
{
    public class CrearCajaLN : ICrearCajaLN
    {
        private readonly ICrearCajaAD _caja;
        private readonly IConvertirACajasTabla _convertirACajasTabla;

        public CrearCajaLN(ICrearCajaAD caja, IConvertirACajasTabla convertirACajasTabla)
        {
            _caja = caja;
            _convertirACajasTabla = convertirACajasTabla;
        }

        public int Crear(CajasDto modelo)
        {
            modelo.estado = true;
            int cantidadDeDatosGuardados =  _caja.Crear(_convertirACajasTabla.ConvertirObjetoACajasTabla(modelo));
            return cantidadDeDatosGuardados;
        }

        public bool VerificarCajaAbierta()
        {
            return _caja.HayCajaAbierta(); // Llama a la capa de acceso a datos
        }
    }
}
