using Abstracciones.AD.Interfaces.Ventas.ListarVenta;
using Abstracciones.Modelos.Ventas;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Ventas.ListarVenta
{
    public class ListarVentaAD : IListarVentaAD
    {
        private readonly Contexto _elContexto;

        public ListarVentaAD(Contexto contexto)
        {
            _elContexto = contexto;
        }

        public List<VentasDto> Listar()
        {
            List<VentasDto> laListaDeVentas = (from laVenta in _elContexto.VentasTabla
                                               select new VentasDto
                                               {
                                                   Venta_ID = laVenta.Venta_ID,
                                                   fecha = laVenta.fecha,
                                                   subtotal = laVenta.subtotal,
                                                   total = laVenta.total,
                                                   Usuario_ID = laVenta.Usuario_ID,
                                                   Caja_ID = laVenta.Caja_ID,
                                                   estado = laVenta.estado
                                               }).ToList();
            return laListaDeVentas;
        }
    }
}
