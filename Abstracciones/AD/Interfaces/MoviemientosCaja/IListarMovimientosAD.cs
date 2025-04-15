using Abstracciones.Modelos.MovimientosCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.MoviemientosCaja
{
    public interface IListarMovimientosAD
    {
        List<MovimientosCajaDto> Listar();

        List<MovimientosCajaDto> ListarPorCaja(int cajaId);

    }
}
