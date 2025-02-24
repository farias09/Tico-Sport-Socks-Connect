using Abstracciones.AD.Interfaces.MoviemientosCaja;
using Abstracciones.LN.Interfaces.General.Conversiones.MovimientosCaja;
using Abstracciones.LN.Interfaces.MovimientosCaja;
using Abstracciones.Modelos.MovimientosCaja;
using System.Threading.Tasks;

namespace LN.MovimientosCaja
{
    public class CrearMovimientoLN : ICrearMovimientoLN
    {
        private readonly ICrearMovimientoAD _movimiento;
        private readonly IConvertirObjetoAMovimientosCajaTabla _convertirAMovimientosCajaTabla;

        public CrearMovimientoLN(ICrearMovimientoAD movimiento, IConvertirObjetoAMovimientosCajaTabla convertirAMovimientosCajaTabla)
        {
            _movimiento = movimiento;
            _convertirAMovimientosCajaTabla = convertirAMovimientosCajaTabla;
        }

        public async Task<int> Guardar(MovimientosCajaDto modelo)
        {
            int cantidadDeDatosGuardados = await _movimiento.Guardar(_convertirAMovimientosCajaTabla.ConvertivetirAMovimientosCajaTabla(modelo));
            return cantidadDeDatosGuardados;
        }

    }
}
