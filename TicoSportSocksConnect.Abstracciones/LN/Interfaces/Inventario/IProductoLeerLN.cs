using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TicoSportSocksConnect.Abstracciones.Modelos.Inventario;

namespace TicoSportSocksConnect.Abstracciones.LN.Interfaces.Inventario
{
    public interface IProductoLeerLN
    {
        Task<List<ProductosDto>> ObtenerTodosAsync();
        Task<ProductosDto> ObtenerPorIdAsync(int id);
    }
}
