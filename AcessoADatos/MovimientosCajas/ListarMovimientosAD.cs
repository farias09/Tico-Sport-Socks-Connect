using Abstracciones.AD.Interfaces.MoviemientosCaja;
using Abstracciones.Modelos.Caja;
using Abstracciones.Modelos.MovimientosCaja;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.MovimientosCajas
{
    public class ListarMovimientosAD : IListarMovimientosAD
    {
        private readonly Contexto _elContexto;

        public ListarMovimientosAD(Contexto contexto)
        {
            _elContexto = contexto;
        }

        public List<MovimientosCajaDto> Listar()
        {
            List<MovimientosCajaDto> laListadeCajas = (from elMovimiento in _elContexto.MovimientosCajaTabla
                                             select new MovimientosCajaDto
                                             {
                                                 MovimientoCaja_ID = elMovimiento.MovimientoCaja_ID,
                                                 Caja_ID = elMovimiento.Caja_ID,
                                                 Fecha = elMovimiento.Fecha,
                                                 Tipo_Movimiento = elMovimiento.Tipo_Movimiento,
                                                 Monto = elMovimiento.Monto,
                                                 Descripcion = elMovimiento.Descripcion,
                                                 Venta_id = elMovimiento.Venta_id,
                                                 Usuario_ID = elMovimiento.Usuario_ID,
                                                 Estado = elMovimiento.Estado

                                             }).ToList();

            return laListadeCajas;
        }

        public List<MovimientosCajaDto> ListarPorCaja(int cajaId)
        {
            return (from elMovimiento in _elContexto.MovimientosCajaTabla
                    where elMovimiento.Caja_ID == cajaId
                    orderby elMovimiento.Fecha descending
                    select new MovimientosCajaDto
                    {
                        MovimientoCaja_ID = elMovimiento.MovimientoCaja_ID,
                        Caja_ID = elMovimiento.Caja_ID,
                        Fecha = elMovimiento.Fecha,
                        Tipo_Movimiento = elMovimiento.Tipo_Movimiento,
                        Monto = elMovimiento.Monto,
                        Descripcion = elMovimiento.Descripcion,
                        Venta_id = elMovimiento.Venta_id,
                        Usuario_ID = elMovimiento.Usuario_ID,
                        Estado = elMovimiento.Estado
                    }).ToList();
        }

    }
}
