using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using TicoSportSocksConnect.Abstracciones.AD.Interfaces.Repositorio;

namespace TicoSportsSocksConnect.AccesoADatos.Repositorio
{
    public class RepositorioDapper : IRepositorioDapper
    {
        private readonly IConfiguration _configuracion;
        private readonly SqlConnection _conexionBaseDatos;

        public RepositorioDapper(IConfiguration configuracion)
        {
            _configuracion = configuracion;
            _conexionBaseDatos = new SqlConnection(_configuracion.GetConnectionString("BD"));
        }

        public SqlConnection ObtenerRepositorio()
        {
            return _conexionBaseDatos;
        }

        SqlConnection IRepositorioDapper.ObtenerRepositorio()
        {
            throw new NotImplementedException();
        }
    }
}
