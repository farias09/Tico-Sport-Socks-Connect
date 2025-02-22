using Abstracciones.LN.Interfaces.General.Conversiones.Ventas.ConvertirAVentasDto;
using Abstracciones.Modelos.Ventas;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LN.General.Conversiones.Ventas.ConvertirAVentasDto
{
    public class ConvertirAVentaDto : IConvertirAVentasDto
    {
        public VentasDto ConvertirObjetoAVentasDTO(VentasTabla laVenta)
        {
            return new VentasDto
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
