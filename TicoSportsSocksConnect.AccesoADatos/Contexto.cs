using Microsoft.EntityFrameworkCore;
using TicoSportSocksConnect.Abstracciones.ModelosBaseDeDatos;

namespace TicoSportsSocksConnect.AccesoADatos
{
    public class Contexto : DbContext
    {
        public Contexto(DbContextOptions<Contexto> options) : base(options) { }

        public DbSet<AuditoriaTabla> Auditoria { get; set; }
        public DbSet<CajasTabla> Cajas { get; set; }
        public DbSet<CarritoTabla> Carrito { get; set; }
        public DbSet<CategoriasTabla> Categorias { get; set; }
        public DbSet<ClientesTabla> Clientes { get; set; }
        public DbSet<OrdenesTabla> Ordenes { get; set; }
        public DbSet<PagosTabla> Pagos { get; set; }
        public DbSet<ProductosTabla> Productos { get; set; }
        public DbSet<ReportesTabla> Reportes { get; set; }
        public DbSet<RolesTabla> Roles { get; set; }
        public DbSet<UsuariosTabla> Usuarios { get; set; }
        public DbSet<VentasTabla> Ventas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Como la tabla de Clientes y Ordenes no tenian entidades tuve que generarselas pero seria bueno poder corregir eso mas adelante
            modelBuilder.Entity<ClientesTabla>()
                .HasKey(c => c.Cliente_ID); // Especifica que Cliente_ID es la clave primaria

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrdenesTabla>()
                .HasKey(o => o.Orden_ID); // Especifica que Orden_ID es la clave primaria

            base.OnModelCreating(modelBuilder);
        }

    }
}
