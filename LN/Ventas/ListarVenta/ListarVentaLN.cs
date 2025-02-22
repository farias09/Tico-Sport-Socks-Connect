using Abstracciones.AD.Interfaces.Ventas.ListarVenta;
using Abstracciones.LN.Interfaces.General.Conversiones.Ventas.ConvertirAVentasDto;
using Abstracciones.LN.Interfaces.Ventas.ListarVenta;
using Abstracciones.Modelos.Ventas;
using Abstracciones.ModelosBaseDeDatos;
using AcessoADatos.Ventas.ListarVenta;
using LN.General.Conversiones.Ventas.ConvertirAVentasDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.Ventas.ListarVenta
{
    public class ListarVentaLN : IListarVentaLN
    {
        private readonly IListarVentaAD _listarVentaAD;
        private readonly IConvertirAVentasDto _convertirAVentasDTO;

        public ListarVentaLN(IListarVentaAD listarVentaAD, IConvertirAVentasDto convertirAVentasDTO)
        {
            _listarVentaAD = listarVentaAD;
            _convertirAVentasDTO = convertirAVentasDTO;
        }

        public List<VentasDto> Listar()
        {
            List <VentasDto> laListaDeVentas = _listarVentaAD.Listar();
            return laListaDeVentas;
        }
    }
}
