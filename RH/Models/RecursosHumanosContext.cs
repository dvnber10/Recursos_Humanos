using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace RH.Models;

public partial class RecursosHumanosContext : DbContext
{
    public RecursosHumanosContext()
    {
    }

    public RecursosHumanosContext(DbContextOptions<RecursosHumanosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Afiliacion> Afiliacions { get; set; }

    public virtual DbSet<Contratacion> Contratacions { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Nomina> Nominas { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=ConnectionStrings:Base");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Afiliacion>(entity =>
        {
            entity.HasKey(e => e.IdAfiliacion);

            entity.ToTable("afiliacion");

            entity.HasIndex(e => e.IdUser, "IX_afiliacion_Id_user");

            entity.Property(e => e.IdAfiliacion).HasColumnName("id_afiliacion");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdUser).HasColumnName("Id_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Afiliacions)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_afiliacion_usuario");
        });

        modelBuilder.Entity<Contratacion>(entity =>
        {
            entity.HasKey(e => e.IdContratacion).HasName("PK__contrata__CD5220878EF9ADB0");

            entity.ToTable("contratacion");

            entity.Property(e => e.IdContratacion).HasColumnName("id_contratacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado);

            entity.ToTable("estado");

            entity.HasIndex(e => e.IdNomina, "IX_estado_id_nomina");

            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Estado1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.IdNomina).HasColumnName("id_nomina");

            entity.HasOne(d => d.IdNominaNavigation).WithMany(p => p.Estados)
                .HasForeignKey(d => d.IdNomina)
                .HasConstraintName("FK_estado_nomina");
        });

        modelBuilder.Entity<Nomina>(entity =>
        {
            entity.HasKey(e => e.IdNomina);

            entity.ToTable("nomina");

            entity.HasIndex(e => e.IdUser, "IX_nomina_id_user");

            entity.Property(e => e.IdNomina)
                .ValueGeneratedNever()
                .HasColumnName("id_nomina");
            entity.Property(e => e.Aumento).HasColumnType("money");
            entity.Property(e => e.CanHoras).HasColumnName("Can_Horas");
            entity.Property(e => e.Descuento)
                .HasColumnType("money")
                .HasColumnName("descuento");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Nominas)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_nomina_usuario");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso);

            entity.ToTable("permisos");

            entity.HasIndex(e => e.IdEstado, "IX_permisos_id_estado");

            entity.Property(e => e.IdPermiso).HasColumnName("id_permiso");
            entity.Property(e => e.Descripcion)
                .IsUnicode(false)
                .HasColumnName("descripcion");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaInicio)
                .HasColumnType("datetime")
                .HasColumnName("fecha_inicio");
            entity.Property(e => e.FechaSolicfitud)
                .HasColumnType("datetime")
                .HasColumnName("fecha_solicfitud");
            entity.Property(e => e.IdEstado).HasColumnName("id_estado");
            entity.Property(e => e.Solicitud)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("solicitud");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Permisos)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_permisos_estado");
        });

        modelBuilder.Entity<Registro>(entity =>
        {
            entity.HasKey(e => e.IdRegistro);

            entity.ToTable("registro");

            entity.HasIndex(e => e.IdUser, "IX_registro_id_user");

            entity.Property(e => e.IdRegistro).HasColumnName("id_registro");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .HasColumnName("fecha_salida");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdUserNavigation).WithMany(p => p.Registros)
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_registro_usuario");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("id_Rol");
            entity.Property(e => e.Rol1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("Rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.ToTable("usuario");

            entity.HasIndex(e => e.Idcontratacion, "IX_usuario_IdUserNavigationIdRol");

            entity.Property(e => e.IdUsuario).HasColumnName("id_usuario");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.Contraseña).IsUnicode(false);
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Curriculum).HasColumnType("image");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Documento).HasColumnName("documento");
            entity.Property(e => e.IdRol).HasColumnName("id_Rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuario_Rol_IdUserNavigationIdRol");

            entity.HasOne(d => d.IdcontratacionNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.Idcontratacion)
                .HasConstraintName("usercont");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
