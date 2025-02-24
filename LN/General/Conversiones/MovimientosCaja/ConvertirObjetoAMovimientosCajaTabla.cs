using Abstracciones.LN.Interfaces.General.Conversiones.MovimientosCaja;
using Abstracciones.Modelos.MovimientosCaja;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.General.Conversiones.MovimientosCaja
{
    public class ConvertirObjetoAMovimientosCajaTabla : IConvertirObjetoAMovimientosCajaTabla
    {
        public MovimientosCajaTabla ConvertivetirAMovimientosCajaTabla(MovimientosCajaDto elMovimiento)
        {
            return new MovimientosCajaTabla
            {
                MovimientoCaja_ID = elMovimiento.MovimientoCaja_ID,
                Caja_ID = elMovimiento.Caja_ID,
                Fecha = elMovimiento.Fecha,
                Tipo_Movimiento = elMovimiento.Tipo_Movimiento,
                Monto = elMovimiento.Monto,
                Descripcion = elMovimiento.Descripcion,
                Venta_id = elMovimiento.Venta_id,
                Usuario_ID = elMovimiento.Usuario_ID,
                Estado = elMovimiento.Estado
            };
        }
    }
}
