using Abstracciones.Modelos.MovimientosCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.MovimientosCaja
{
    public interface IListarMovimientosLN
    {
        List<MovimientosCajaDto> Listar();

        List<MovimientosCajaDto> ListarPorCaja(int cajaId);

    }
}
