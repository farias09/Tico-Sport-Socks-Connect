using Abstracciones.AD.Interfaces.Cajas.CerrarCaja;
using AccesoADatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoADatos.Cajas.CerrarCaja
{
    public class CerrarCajaAD : ICerrarCajaAD
    {
        private readonly Contexto _contexto;

        public CerrarCajaAD(Contexto contexto)
        {
            _contexto = contexto;
        }
        public bool CerrarCaja(int cajaId, decimal montoFinal)
        {
            var caja = _contexto.CajasTabla.FirstOrDefault(c => c.Caja_ID == cajaId && c.estado);

            if (caja == null) return false;

            // Calcula totales antes de cerrar (puedes modificar esto si ya tienes lógica en otro lado)
            var movimientos = _contexto.MovimientosCajaTabla
                .Where(m => m.Caja_ID == cajaId && m.Estado)
                .ToList();

            var totalIngresos = movimientos
                .Where(m => m.Tipo_Movimiento == "Ingreso")
                .Sum(m => m.Monto);

            var totalEgresos = movimientos
                .Where(m => m.Tipo_Movimiento == "Egreso")
                .Sum(m => m.Monto);

            caja.fecha_cierre = DateTime.Now;
            caja.monto_final = montoFinal;
            caja.total_ventas = totalIngresos;
            caja.total_gastos = totalEgresos;
            caja.estado = false;

            return _contexto.SaveChanges() > 0;
        }

    }
}
