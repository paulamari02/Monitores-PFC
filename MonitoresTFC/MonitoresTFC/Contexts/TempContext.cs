using Microsoft.EntityFrameworkCore;
using MonitoresTFC.Models.Monitors;

namespace MonitoresTFC.Contexts;

public partial class TempContext : DbContext
{
    public TempContext()
    {
    }

    public TempContext(DbContextOptions<TempContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Listadoentradaalmacen> Listadoentradaalmacens { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=127.0.0.1;uid=root;pwd=Admin;database=monitores;port=3306", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.33-mysql"));
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

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

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
