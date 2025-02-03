using Abstracciones.LN.Interfaces.General.Conversiones.Usuarios.ConvertirAUsuariosTabla;
using Abstracciones.Modelos.Caja;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.General.Conversiones.Cajas.ConvertirACajasTabla
{
    public class ConvertirACajasTabla : IConvertirACajasTabla
    {
        public CajasTabla ConvertirObjetoACajasTabla(CajasDto laCaja)
        {
            return new CajasTabla
            {
                Caja_ID = laCaja.Caja_ID,
                nombre_caja = laCaja.nombre_caja,
                fecha_apertura = laCaja.fecha_apertura,
                fecha_cierre = laCaja.fecha_cierre,
                monto_final = laCaja.monto_final,
                monto_inicial = laCaja.monto_inicial,
                total_ventas = laCaja.total_ventas,
                total_gastos = laCaja.total_gastos,
                estado = laCaja.estado,
                Usuario_ID = laCaja.Usuario_ID
            };
        }
    }
}
