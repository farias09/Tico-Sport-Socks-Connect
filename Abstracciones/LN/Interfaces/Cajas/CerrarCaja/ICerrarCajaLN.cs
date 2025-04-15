using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Cajas.CerrarCaja
{
    public interface ICerrarCajaLN
    {
        bool CerrarCaja(int cajaId, decimal montoFinal);
    }
}
