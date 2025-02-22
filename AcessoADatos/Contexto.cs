using Abstracciones.ModelosBaseDeDatos;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace AccesoADatos
{
    public class Contexto : DbContext
    {
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AuditoriaTabla>().ToTable("Auditoria");
            modelBuilder.Entity<CajasTabla>().ToTable("Cajas");
            modelBuilder.Entity<CarritoTabla>().ToTable("Carrito");
            modelBuilder.Entity<CategoriasTabla>().ToTable("Categorias");
            modelBuilder.Entity<MensajesTabla>().ToTable("Mensajes");
            modelBuilder.Entity<PagosTabla>().ToTable("Pagos");
            modelBuilder.Entity<ProductosTabla>().ToTable("Productos");
            modelBuilder.Entity<ReportesTabla>().ToTable("Reportes");
            modelBuilder.Entity<VentasTabla>().ToTable("Ventas");
            modelBuilder.Entity<UsuariosTabla>().ToTable("Usuarios");
        }

        public DbSet<AuditoriaTabla> AuditoriaTabla { get; set; }
        public DbSet<CajasTabla> CajasTabla { get; set; }
        public DbSet<CarritoTabla> CarritoTabla { get; set; }
        public DbSet<CategoriasTabla> CategoriaTabla { get; set; }
        public DbSet<MensajesTabla> MensajesTabla { get; set; }
        public DbSet<PagosTabla> PagosTabla { get; set; }
        public DbSet<ProductosTabla> ProductosTabla { get; set; }
        public DbSet<ReportesTabla> ReportesTabla { get; set; }
        public DbSet<VentasTabla> VentasTabla { get; set; }
        public DbSet<UsuariosTabla> UsuariosTabla { get; set; }

    }
}
