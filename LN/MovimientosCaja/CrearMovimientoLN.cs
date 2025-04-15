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
            // Convertir el DTO a la entidad de base de datos
            var entidad = _convertirAMovimientosCajaTabla.ConvertivetirAMovimientosCajaTabla(modelo);

            // Guardar y obtener el ID del nuevo movimiento
            int idMovimiento = await _movimiento.Guardar(entidad);

            return idMovimiento; // Devuelve el ID real generado por la base de datos
        }

    }
}
