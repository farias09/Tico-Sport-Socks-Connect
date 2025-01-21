using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Entities.Entities;

public partial class DbTicoSportsSocksConnectContext : DbContext
{
    public DbTicoSportsSocksConnectContext()
    {
    }

    public DbTicoSportsSocksConnectContext(DbContextOptions<DbTicoSportsSocksConnectContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Auditorium> Auditoria { get; set; }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Carrito> Carritos { get; set; }

    public virtual DbSet<Categoria> Categorias { get; set; }

    public virtual DbSet<Mensaje> Mensajes { get; set; }

    public virtual DbSet<MovimientosCaja> MovimientosCajas { get; set; }

    public virtual DbSet<Pago> Pagos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Reporte> Reportes { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=DESKTOP-MEA412L\\SQLEXPRESS;Database=DB_TicoSportsSocksConnect;Integrated Security=True;Trusted_Connection=True; TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Auditorium>(entity =>
        {
            entity.HasKey(e => e.AuditoriaId).HasName("PK__Auditori__D7259D326ECD77CE");

            entity.Property(e => e.AuditoriaId).HasColumnName("Auditoria_ID");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Fecha)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.RegistroId).HasColumnName("registro_ID");
            entity.Property(e => e.TablaAfectada)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tabla_afectada");
            entity.Property(e => e.TipoAccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("tipo_accion");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            entity.Property(e => e.ValorAnterior)
                .HasColumnType("text")
                .HasColumnName("valor_anterior");
            entity.Property(e => e.ValorNuevo)
                .HasColumnType("text")
                .HasColumnName("valor_nuevo");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Auditoria)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Auditoria__Usuar__6B24EA82");
        });

        modelBuilder.Entity<Caja>(entity =>
        {
            entity.HasKey(e => e.CajaId).HasName("PK__Cajas__2FBEF8501D55C48C");

            entity.Property(e => e.CajaId).HasColumnName("Caja_ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.FechaApertura)
                .HasColumnType("datetime")
                .HasColumnName("fecha_apertura");
            entity.Property(e => e.FechaCierre)
                .HasColumnType("datetime")
                .HasColumnName("fecha_cierre");
            entity.Property(e => e.MontoFinal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto_final");
            entity.Property(e => e.MontoInicial)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto_inicial");
            entity.Property(e => e.TotalGastos)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_gastos");
            entity.Property(e => e.TotalVentas)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total_ventas");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Cajas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Cajas__Usuario_I__5441852A");
        });

        modelBuilder.Entity<Carrito>(entity =>
        {
            entity.HasKey(e => e.CarritoId).HasName("PK__Carrito__FFEE991480179111");

            entity.ToTable("Carrito");

            entity.Property(e => e.CarritoId).HasColumnName("Carrito_ID");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.PrecioUnitario)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio_unitario");
            entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.VentaId).HasColumnName("Venta_ID");

            entity.HasOne(d => d.Producto).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.ProductoId)
                .HasConstraintName("FK__Carrito__Product__5BE2A6F2");

            entity.HasOne(d => d.Venta).WithMany(p => p.Carritos)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("FK__Carrito__Venta_I__5AEE82B9");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaId).HasName("PK__Categori__C929A10A9EC4F17C");

            entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Mensaje>(entity =>
        {
            entity.HasKey(e => e.MensajeId).HasName("PK__Mensajes__0146A34A20F926A2");

            entity.Property(e => e.MensajeId).HasColumnName("Mensaje_ID");
            entity.Property(e => e.Contenido)
                .HasColumnType("text")
                .HasColumnName("contenido");
            entity.Property(e => e.EmisorId).HasColumnName("emisor_ID");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.ReceptorId).HasColumnName("receptor_ID");

            entity.HasOne(d => d.Emisor).WithMany(p => p.MensajeEmisors)
                .HasForeignKey(d => d.EmisorId)
                .HasConstraintName("FK__Mensajes__emisor__6E01572D");

            entity.HasOne(d => d.Receptor).WithMany(p => p.MensajeReceptors)
                .HasForeignKey(d => d.ReceptorId)
                .HasConstraintName("FK__Mensajes__recept__6EF57B66");
        });

        modelBuilder.Entity<MovimientosCaja>(entity =>
        {
            entity.HasKey(e => e.MovimientoCajaId).HasName("PK__Movimien__75AFA1D19B0D7CA5");

            entity.ToTable("MovimientosCaja");

            entity.Property(e => e.MovimientoCajaId).HasColumnName("MovimientoCaja_ID");
            entity.Property(e => e.CajaId).HasColumnName("Caja_ID");
            entity.Property(e => e.Descripcion).HasColumnType("text");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Monto).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.TipoMovimiento)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Tipo_Movimiento");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            entity.Property(e => e.VentaId).HasColumnName("Venta_id");

            entity.HasOne(d => d.Caja).WithMany(p => p.MovimientosCajas)
                .HasForeignKey(d => d.CajaId)
                .HasConstraintName("FK__Movimient__Caja___628FA481");

            entity.HasOne(d => d.Usuario).WithMany(p => p.MovimientosCajas)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Movimient__Usuar__6477ECF3");

            entity.HasOne(d => d.Venta).WithMany(p => p.MovimientosCajas)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("FK__Movimient__Venta__6383C8BA");
        });

        modelBuilder.Entity<Pago>(entity =>
        {
            entity.HasKey(e => e.PagoId).HasName("PK__Pagos__6A1940A1CD0E483F");

            entity.Property(e => e.PagoId).HasColumnName("Pago_ID");
            entity.Property(e => e.CajaId).HasColumnName("Caja_ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.MetodoPago)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("metodo_pago");
            entity.Property(e => e.Monto)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("monto");
            entity.Property(e => e.ReferenciaTransaccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("referencia_transaccion");
            entity.Property(e => e.VentaId).HasColumnName("Venta_ID");

            entity.HasOne(d => d.Caja).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.CajaId)
                .HasConstraintName("FK__Pagos__Caja_ID__5FB337D6");

            entity.HasOne(d => d.Venta).WithMany(p => p.Pagos)
                .HasForeignKey(d => d.VentaId)
                .HasConstraintName("FK__Pagos__Venta_ID__5EBF139D");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.ProductoId).HasName("PK__Producto__9F1B153D3F433F97");

            entity.Property(e => e.ProductoId).HasColumnName("Producto_ID");
            entity.Property(e => e.CategoriaId).HasColumnName("Categoria_ID");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Imagen)
                .HasMaxLength(1024)
                .IsUnicode(false)
                .HasColumnName("imagen");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Stock).HasColumnName("stock");

            entity.HasOne(d => d.Categoria).WithMany(p => p.Productos)
                .HasForeignKey(d => d.CategoriaId)
                .HasConstraintName("FK__Productos__Categ__5165187F");
        });

        modelBuilder.Entity<Reporte>(entity =>
        {
            entity.HasKey(e => e.ReporteId).HasName("PK__Reportes__41A1FAF343894E93");

            entity.Property(e => e.ReporteId).HasColumnName("Reporte_ID");
            entity.Property(e => e.FechaGeneracion)
                .HasColumnType("datetime")
                .HasColumnName("fecha_generacion");
            entity.Property(e => e.Formato)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("formato");
            entity.Property(e => e.Periodo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("periodo");
            entity.Property(e => e.TipoReporte)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("tipo_reporte");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Reportes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Reportes__Usuari__6754599E");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RolId).HasName("PK__Roles__795EBD69CC9B65A4");

            entity.Property(e => e.RolId).HasColumnName("Rol_ID");
            entity.Property(e => e.Descripcion)
                .HasColumnType("text")
                .HasColumnName("descripcion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.UsuarioId).HasName("PK__Usuarios__77111335FD2A7F35");

            entity.HasIndex(e => e.Email, "UQ__Usuarios__AB6E616468FF9BD5").IsUnique();

            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");
            entity.Property(e => e.Direccion)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.Estado).HasColumnName("estado");
            entity.Property(e => e.Nombre)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("provincia");
            entity.Property(e => e.RolId).HasColumnName("Rol_ID");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Rol).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.RolId)
                .HasConstraintName("FK__Usuarios__Rol_ID__4CA06362");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.VentaId).HasName("PK__Ventas__24B17710966D1DEA");

            entity.Property(e => e.VentaId).HasColumnName("Venta_ID");
            entity.Property(e => e.CajaId).HasColumnName("Caja_ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.Fecha)
                .HasColumnType("datetime")
                .HasColumnName("fecha");
            entity.Property(e => e.Subtotal)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("subtotal");
            entity.Property(e => e.Total)
                .HasColumnType("decimal(18, 2)")
                .HasColumnName("total");
            entity.Property(e => e.UsuarioId).HasColumnName("Usuario_ID");

            entity.HasOne(d => d.Caja).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CajaId)
                .HasConstraintName("FK__Ventas__Caja_ID__5812160E");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Venta)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__Ventas__Usuario___571DF1D5");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
