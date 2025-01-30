using Microsoft.EntityFrameworkCore;
using TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos;

namespace TicoSportsSocksConnect.AccesoADatos
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<CajaTabla> Cajas { get; set; }
        public DbSet<ClientesTabla> Clientes { get; set; }
        public DbSet<FacturaTabla> Facturas { get; set; }
        public DbSet<InventarioTabla> Productos { get; set; }
        public DbSet<ListaOrdenesTabla> ListaOrdenes { get; set; }
        public DbSet<OrdenesTabla> Ordenes { get; set; }
        public DbSet<ReportesTabla> Reportes { get; set; }
        public DbSet<UsuariosTabla> Usuarios { get; set; }
    }
}
