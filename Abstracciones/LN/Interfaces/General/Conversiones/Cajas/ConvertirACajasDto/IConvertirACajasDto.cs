using Abstracciones.Modelos.Caja;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.General.Conversiones.Cajas.ConvertirACajasDto
{
    public interface IConvertirACajasDto
    {
        CajasDto ConvertirObjetoACajasDto(CajasTabla laCaja);
    }
}
