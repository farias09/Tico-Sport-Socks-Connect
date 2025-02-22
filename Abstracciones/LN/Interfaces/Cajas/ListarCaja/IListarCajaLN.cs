using Abstracciones.Modelos.Caja;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.LN.Interfaces.Cajas.ListarCaja
{
    public interface IListarCajaLN
    {
        List<CajasDto> Listar();
    }
}
