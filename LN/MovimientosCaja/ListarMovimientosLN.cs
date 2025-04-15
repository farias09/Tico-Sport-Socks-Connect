using Abstracciones.AD.Interfaces.Cajas.ListarCaja;
using Abstracciones.AD.Interfaces.MoviemientosCaja;
using Abstracciones.LN.Interfaces.General.Conversiones.Cajas.ConvertirACajasDto;
using Abstracciones.LN.Interfaces.General.Conversiones.MovimientosCaja;
using Abstracciones.LN.Interfaces.MovimientosCaja;
using Abstracciones.Modelos.Caja;
using Abstracciones.Modelos.MovimientosCaja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.MovimientosCaja
{
    public class ListarMovimientosLN : IListarMovimientosLN
    {
        private readonly IListarMovimientosAD _listarMovimientosAD;
        private readonly IConvertirObjetoAMovimientosCajaDto _convertirAMovimientosCajaDto;

        public ListarMovimientosLN(IListarMovimientosAD listarMovimientosAD, IConvertirObjetoAMovimientosCajaDto convertirAMovimientosCajaDto)
        {
            this._listarMovimientosAD = listarMovimientosAD;
            this._convertirAMovimientosCajaDto = convertirAMovimientosCajaDto;
        }

        public List<MovimientosCajaDto> Listar()
        {
            List<MovimientosCajaDto> laListaDeMovimientos = _listarMovimientosAD.Listar();
            return laListaDeMovimientos;
        }

        public List<MovimientosCajaDto> ListarPorCaja(int cajaId)
        {
            return _listarMovimientosAD.ListarPorCaja(cajaId);
        }

    }
}
