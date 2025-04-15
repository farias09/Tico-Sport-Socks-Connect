using Abstracciones.AD.Interfaces.Cajas.ListarCaja;
using Abstracciones.Modelos.Caja;
using AccesoADatos;
using System.Collections.Generic;
using System.Linq;

namespace AcessoADatos.Cajas.ListarCaja
{
    public class ListarCajaAD : IListarCajaAD
    {
        private readonly Contexto _elContexto;

        public ListarCajaAD (Contexto contexto)
        {
            _elContexto = contexto;
        }

        public List<CajasDto> Listar()
        {
            List<CajasDto> laListadeCajas = (from laCaja in _elContexto.CajasTabla
                                             select new CajasDto
                                             {
                                                 Caja_ID = laCaja.Caja_ID,
                                                 nombre_caja = laCaja.nombre_caja,
                                                 fecha_apertura = laCaja.fecha_apertura,
                                                 fecha_cierre = laCaja.fecha_cierre,
                                                 monto_inicial = laCaja.monto_inicial,
                                                 monto_final = laCaja.monto_final,
                                                 total_ventas = laCaja.total_ventas,
                                                 total_gastos = laCaja.total_gastos,
                                                 estado = laCaja.estado,
                                                 Usuario_ID = laCaja.Usuario_ID
                                             }).ToList();

            return laListadeCajas;
        }

        public CajasDto ObtenerCajaPorId(int id)
        {
            var laCaja = _elContexto.CajasTabla.FirstOrDefault(c => c.Caja_ID == id);

            if (laCaja == null)
                return null;

            return new CajasDto
            {
                Caja_ID = laCaja.Caja_ID,
                nombre_caja = laCaja.nombre_caja,
                fecha_apertura = laCaja.fecha_apertura,
                fecha_cierre = laCaja.fecha_cierre,
                monto_inicial = laCaja.monto_inicial,
                monto_final = laCaja.monto_final,
                total_ventas = laCaja.total_ventas,
                total_gastos = laCaja.total_gastos,
                estado = laCaja.estado,
                Usuario_ID = laCaja.Usuario_ID
            };
        }
    }
}
