using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace SYK.Models;

public partial class SykContext : DbContext
{
    public SykContext()
    {
    }

    public SykContext(DbContextOptions<SykContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Descripcionservicio> Descripcionservicios { get; set; }

    public virtual DbSet<Recepcionequipo> Recepcionequipos { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;port=3306;database=syk;uid=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("10.4.32-mariadb"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8_general_ci")
            .HasCharSet("utf8");

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("cliente");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Apellido).HasMaxLength(45);
            entity.Property(e => e.Correo).HasMaxLength(45);
            entity.Property(e => e.Dirrecion).HasMaxLength(30);
            entity.Property(e => e.Estado).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Telefono).HasMaxLength(45);
        });

        modelBuilder.Entity<Descripcionservicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("descripcionservicio");

            entity.HasIndex(e => e.ServicioId, "fk_DescripcionServicio_Servicio1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.ServicioId)
                .HasColumnType("int(11)")
                .HasColumnName("Servicio_id");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Descripcionservicios)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_DescripcionServicio_Servicio1");
        });

        modelBuilder.Entity<Recepcionequipo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("recepcionequipo");

            entity.HasIndex(e => e.ClienteId, "fk_RecepcionEquipo_Cliente_idx");

            entity.HasIndex(e => e.ServicioId, "fk_RecepcionEquipo_Servicio1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Accesorio).HasMaxLength(400);
            entity.Property(e => e.CapacidadAlmacenamiento).HasMaxLength(60);
            entity.Property(e => e.CapacidadRam).HasColumnType("int(11)");
            entity.Property(e => e.ClienteId)
                .HasColumnType("int(11)")
                .HasColumnName("Cliente_id");
            entity.Property(e => e.Fecha).HasColumnType("datetime");
            entity.Property(e => e.Grafico).HasMaxLength(60);
            entity.Property(e => e.MarcaPc).HasMaxLength(60);
            entity.Property(e => e.ModeloPc).HasMaxLength(60);
            entity.Property(e => e.Nserie)
                .HasMaxLength(100)
                .HasColumnName("NSerie");
            entity.Property(e => e.ServicioId)
                .HasColumnType("int(11)")
                .HasColumnName("Servicio_id");
            entity.Property(e => e.TipoAlmacenamiento).HasColumnType("int(11)");
            entity.Property(e => e.TipoGpu).HasColumnType("int(11)");
            entity.Property(e => e.TipoPc).HasColumnType("int(11)");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Recepcionequipos)
                .HasForeignKey(d => d.ClienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_RecepcionEquipo_Cliente");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Recepcionequipos)
                .HasForeignKey(d => d.ServicioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_RecepcionEquipo_Servicio1");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("servicio");

            entity.HasIndex(e => e.UsuarioId, "fk_Servicio_Usuario1_idx");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Estado).HasColumnType("int(11)");
            entity.Property(e => e.Nombre).HasMaxLength(60);
            entity.Property(e => e.Precio).HasColumnType("int(11)");
            entity.Property(e => e.Sku).HasMaxLength(50);
            entity.Property(e => e.UsuarioId)
                .HasColumnType("int(11)")
                .HasColumnName("Usuario_id");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Servicios)
                .HasForeignKey(d => d.UsuarioId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_Servicio_Usuario1");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("usuario");

            entity.Property(e => e.Id)
                .HasColumnType("int(11)")
                .HasColumnName("id");
            entity.Property(e => e.Apellido).HasMaxLength(45);
            entity.Property(e => e.Correo).HasMaxLength(45);
            entity.Property(e => e.Nombre).HasMaxLength(45);
            entity.Property(e => e.Password).HasMaxLength(45);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
