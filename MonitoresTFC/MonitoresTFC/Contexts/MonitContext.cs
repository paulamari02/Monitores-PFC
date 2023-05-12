using Microsoft.EntityFrameworkCore;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Contexts;

public partial class MonitContext : DbContext
{
    public MonitContext()
    {
    }

    public MonitContext(DbContextOptions<MonitContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Listadocliente> Listadoclientes { get; set; }
    public virtual DbSet<Listadopedido> Listadopedidos { get; set; }
    public virtual DbSet<Listadoproveedore> Listadoproveedores { get; set; }
    public virtual DbSet<Listadoarticulo> Listadoarticulos { get; set; }
    public virtual DbSet<Listadoentradaalmacen> Listadoentradaalmacens { get; set; }
    public virtual DbSet<Listadosalidasalmacen> Listadosalidasalmacens { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=Admin;database=monitores;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<Listadocliente>(entity =>
        {
            entity.HasKey(e => e.IdCliente).HasName("PRIMARY");

            entity.ToTable("listadoclientes");

            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Apellidos)
                .HasMaxLength(50)
                .HasColumnName("apellidos");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(50)
                .HasColumnName("codigo_postal");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Fechaalta).HasColumnName("fechaalta");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(50)
                .HasDefaultValueSql("'*'")
                .HasColumnName("observaciones");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Listadopedido>(entity =>
        {
            entity.HasKey(e => e.IdPedido).HasName("PRIMARY");

            entity.ToTable("listadopedidos");

            entity.HasIndex(e => e.IdCliente, "id_cliente");

            entity.Property(e => e.IdPedido).HasColumnName("id_pedido");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .HasDefaultValueSql("'*'")
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaPedido).HasColumnName("fecha_pedido");
            entity.Property(e => e.IdCliente).HasColumnName("id_cliente");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.StatusPedido)
                .HasMaxLength(50)
                .HasColumnName("status_pedido");
        });

        modelBuilder.Entity<Listadoproveedore>(entity =>
        {
            entity.HasKey(e => e.IdProveedor).HasName("PRIMARY");

            entity.ToTable("listadoproveedores");

            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(50)
                .HasColumnName("codigo_postal");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .HasColumnName("direccion");
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .HasColumnName("email");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .HasColumnName("nombre");
            entity.Property(e => e.NumFiscal)
                .HasMaxLength(50)
                .HasColumnName("num_fiscal");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(50)
                .HasDefaultValueSql("'*'")
                .HasColumnName("observaciones");
            entity.Property(e => e.Telefono)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("telefono");
        });

        modelBuilder.Entity<Listadoarticulo>(entity =>
        {
            entity.HasKey(e => e.IdArticulo).HasName("PRIMARY");

            entity.ToTable("listadoarticulos");

            entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");
            entity.Property(e => e.Articulo)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("articulo");
            entity.Property(e => e.CodArticulo)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("cod_articulo");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
            entity.Property(e => e.Observaciones)
                .HasMaxLength(50)
                .HasDefaultValueSql("'*'")
                .HasColumnName("observaciones");
            entity.Property(e => e.Status)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("status");
        });

        modelBuilder.Entity<Listadoentradaalmacen>(entity =>
        {
            entity.HasKey(e => e.IdEntrada).HasName("PRIMARY");

            entity.ToTable("listadoentradaalmacen");

            entity.Property(e => e.IdEntrada).HasColumnName("id_entrada");
            entity.Property(e => e.Albaran)
                .HasMaxLength(50)
                .HasDefaultValueSql("''")
                .HasColumnName("albaran");
            entity.Property(e => e.Bultos)
                .HasMaxLength(50)
                .HasColumnName("bultos");
            entity.Property(e => e.Cantidad)
                .HasMaxLength(50)
                .HasColumnName("cantidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.FechaEntrada).HasColumnName("fecha_entrada");
            entity.Property(e => e.FechaTransito).HasColumnName("fecha_transito");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
        });

        modelBuilder.Entity<Listadosalidasalmacen>(entity =>
        {
            entity.HasKey(e => e.IdSalidas).HasName("PRIMARY");

            entity.ToTable("listadosalidasalmacen");

            entity.Property(e => e.IdSalidas).HasColumnName("id_salidas");
            entity.Property(e => e.Albaran)
                .HasMaxLength(50)
                .HasColumnName("albaran");
            entity.Property(e => e.Bultos)
                .HasMaxLength(50)
                .HasColumnName("bultos");
            entity.Property(e => e.Cantidad)
                .HasMaxLength(50)
                .HasColumnName("cantidad");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
            entity.Property(e => e.FechaSalida).HasColumnName("fecha_salida");
            entity.Property(e => e.IdArticulo).HasColumnName("id_articulo");
            entity.Property(e => e.IdProveedor).HasColumnName("id_proveedor");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
