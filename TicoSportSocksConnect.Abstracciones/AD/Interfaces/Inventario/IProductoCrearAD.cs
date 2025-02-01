using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicoSportSocksConnect.Abstracciones.Modelos.Inventario;

namespace TicoSportSocksConnect.Abstracciones.AD.Interfaces.Inventario
{
    public interface IProductoCrearAD
    {
        Task CrearAsync(ProductosDto producto);
    }
}
