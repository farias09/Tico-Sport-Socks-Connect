using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Cajas.CerrarCaja
{
    public interface ICerrarCajaAD
    {
        bool CerrarCaja(int cajaId, decimal montoFinal);
    }
}
