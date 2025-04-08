using Abstracciones.AD.Interfaces.Cajas.ListarCaja;
using Abstracciones.LN.Interfaces.Cajas.ListarCaja;
using Abstracciones.LN.Interfaces.General.Conversiones.Cajas.ConvertirACajasDto;
using Abstracciones.Modelos.Caja;
using System.Collections.Generic;

namespace LN.Cajas.ListarCaja
{
    public class ListarCajaLN : IListarCajaLN
    {
        private readonly IListarCajaAD _listarCajaAD;
        private readonly IConvertirACajasDto convertirACajasDto;

        public ListarCajaLN(IListarCajaAD listarCajaAD, IConvertirACajasDto convertirACajasDto)
        {
            this._listarCajaAD = listarCajaAD;
            this.convertirACajasDto = convertirACajasDto;
        }

        public List<CajasDto> Listar()
        {
            List<CajasDto> laListaDeCajas = _listarCajaAD.Listar();
            return laListaDeCajas;
        }
        public CajasDto ObtenerCajaPorId(int id)
        {
            return _listarCajaAD.ObtenerCajaPorId(id);
        }
    }
}
