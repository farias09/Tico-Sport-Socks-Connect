using Abstracciones.Modelos.MovimientosCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.MovimientosCaja
{
    public interface ICrearMovimientoLN
    {
        Task<int> Guardar(MovimientosCajaDto modelo);
    }
}
