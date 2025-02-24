using Abstracciones.Modelos.MovimientosCaja;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.General.Conversiones.MovimientosCaja
{
    public interface IConvertirObjetoAMovimientosCajaDto
    {
        MovimientosCajaDto ConvertivetirAMovimientosCajaDto(MovimientosCajaTabla elMovimiento);
    }
}
