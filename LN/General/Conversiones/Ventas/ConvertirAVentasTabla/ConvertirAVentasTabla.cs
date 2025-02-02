using Abstracciones.LN.Interfaces.General.Conversiones.Ventas.ConvertirAVentasTabla;
using Abstracciones.Modelos.Ventas;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.General.Conversiones.Ventas.ConvertirAVentasTabla
{
    public class ConvertirAVentasTabla : IConvertirAVentasTabla
    {
        public VentasTabla ConvertirObjetoAVentasTabla(VentasDto laVenta)
        {
           return new VentasTabla
           {
               fecha = laVenta.fecha,
               subtotal = laVenta.subtotal,
               total = laVenta.total,
               Usuario_ID = laVenta.Usuario_ID,
               Caja_ID = laVenta.Caja_ID
           };
        }
    }
}
