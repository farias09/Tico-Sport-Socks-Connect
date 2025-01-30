using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicoSportSocksConnect.Abstracciones.AD.Interfaces.Repositorio
{
    public interface IRepositorioDapper
    {
        SqlConnection ObtenerRepositorio();
    }
}
