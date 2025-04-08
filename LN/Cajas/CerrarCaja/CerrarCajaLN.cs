using Abstracciones.AD.Interfaces.Cajas.CerrarCaja;
using Abstracciones.LN.Interfaces.Cajas.CerrarCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Cajas.CerrarCaja
{
    public class CerrarCajaLN : ICerrarCajaLN
    {
        private readonly ICerrarCajaAD _cerrarCajaAD;

        public CerrarCajaLN(ICerrarCajaAD cerrarCajaAD)
        {
            _cerrarCajaAD = cerrarCajaAD;
        }

        public bool CerrarCaja(int cajaId, decimal montoFinal)
        {
            return _cerrarCajaAD.CerrarCaja(cajaId, montoFinal);
        }

    }
}
