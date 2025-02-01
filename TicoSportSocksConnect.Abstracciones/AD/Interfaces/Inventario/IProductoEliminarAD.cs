using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.AD.Interfaces.Inventario
{
    public interface IProductoEliminarAD
    {
        Task EliminarAsync(int id);
    }
}
