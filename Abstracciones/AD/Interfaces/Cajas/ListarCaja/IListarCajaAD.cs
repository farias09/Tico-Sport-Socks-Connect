using Abstracciones.Modelos.Caja;
using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstracciones.AD.Interfaces.Cajas.ListarCaja
{
    public interface IListarCajaAD
    {
        List<CajasDto> Listar();
    }
}
