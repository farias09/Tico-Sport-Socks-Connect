using Abstracciones.Modelos.Ventas;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.General.Conversiones.Ventas.ConvertirAVentasDto
{
    public interface IConvertirAVentasDto
    {
        VentasDto ConvertirObjetoAVentasDTO(VentasTabla laVenta);
    }
}
