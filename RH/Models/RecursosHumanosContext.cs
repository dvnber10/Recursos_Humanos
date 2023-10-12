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

    public virtual DbSet<Access> Accesses { get; set; }

    public virtual DbSet<Afiliacion> Afiliacions { get; set; }

    public virtual DbSet<Aspirante> Aspirantes { get; set; }

    public virtual DbSet<Contratacion> Contratacions { get; set; }

    public virtual DbSet<Estado> Estados { get; set; }

    public virtual DbSet<Nomina> Nominas { get; set; }

    public virtual DbSet<Permiso> Permisos { get; set; }

    public virtual DbSet<Registro> Registros { get; set; }

    public virtual DbSet<Rol> Rols { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    public virtual DbSet<UsuarioRegistro> UsuarioRegistros { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer("Name=Database");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Access>(entity =>
        {
            entity.HasKey(e => e.IdPass).HasName("PK__Access__405F3AE0A613EA54");

            entity.ToTable("Access");

            entity.HasIndex(e => e.Pass, "UQ__Access__8320F63E1FAE4EC6").IsUnique();

            entity.Property(e => e.IdPass)
                .ValueGeneratedNever()
                .HasColumnName("Id_pass");
            entity.Property(e => e.Pass)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("pass");
        });

        modelBuilder.Entity<Afiliacion>(entity =>
        {
            entity.HasKey(e => e.IdAfiliacion);

            entity.ToTable("afiliacion");

            entity.Property(e => e.IdAfiliacion)
                .ValueGeneratedNever()
                .HasColumnName("id_afiliacion");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Aspirante>(entity =>
        {
            entity.HasKey(e => e.IdAspirante);

            entity.ToTable("aspirante");

            entity.Property(e => e.IdAspirante)
                .ValueGeneratedNever()
                .HasColumnName("id_aspirante");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Curriculum)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("curriculum");
            entity.Property(e => e.IdRegis).HasColumnName("id_regis");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.IdRegisNavigation).WithMany(p => p.Aspirantes)
                .HasForeignKey(d => d.IdRegis)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_aspirante_registro");
        });

        modelBuilder.Entity<Contratacion>(entity =>
        {
            entity.HasKey(e => e.IdContratacion);

            entity.ToTable("contratacion");

            entity.Property(e => e.IdContratacion)
                .ValueGeneratedNever()
                .HasColumnName("id_contratacion");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.IdAsp).HasColumnName("id_asp");

            entity.HasOne(d => d.IdAspNavigation).WithMany(p => p.Contratacions)
                .HasForeignKey(d => d.IdAsp)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_contratacion_aspirante");
        });

        modelBuilder.Entity<Estado>(entity =>
        {
            entity.HasKey(e => e.IdEstado);

            entity.ToTable("estado");

            entity.Property(e => e.IdEstado)
                .ValueGeneratedNever()
                .HasColumnName("id_estado");
            entity.Property(e => e.Estado1)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("estado");
            entity.Property(e => e.IdNom).HasColumnName("id_nom");
            entity.Property(e => e.IdPerm).HasColumnName("id_perm");

            entity.HasOne(d => d.IdNomNavigation).WithMany(p => p.Estados)
                .HasForeignKey(d => d.IdNom)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_estado_nomina");
        });

        modelBuilder.Entity<Nomina>(entity =>
        {
            entity.HasKey(e => e.IdNomina);

            entity.ToTable("nomina");

            entity.Property(e => e.IdNomina)
                .ValueGeneratedNever()
                .HasColumnName("id_nomina");
            entity.Property(e => e.Aumento).HasColumnName("aumento");
            entity.Property(e => e.CantHoras).HasColumnName("cant_horas");
            entity.Property(e => e.Descuento).HasColumnName("descuento");
            entity.Property(e => e.IdPermisos).HasColumnName("id_permisos");
        });

        modelBuilder.Entity<Permiso>(entity =>
        {
            entity.HasKey(e => e.IdPermiso);

            entity.ToTable("permisos");

            entity.Property(e => e.IdPermiso)
                .ValueGeneratedNever()
                .HasColumnName("id_permiso");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(50)
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

            entity.Property(e => e.IdRegistro)
                .ValueGeneratedNever()
                .HasColumnName("id_registro");
            entity.Property(e => e.FechaIngreso)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ingreso");
            entity.Property(e => e.FechaSalida)
                .HasColumnType("datetime")
                .HasColumnName("fecha_salida");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol);

            entity.ToTable("Rol");

            entity.Property(e => e.IdRol)
                .ValueGeneratedNever()
                .HasColumnName("id_rol");
            entity.Property(e => e.NombreRol)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_rol");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__4E3E04ADC9C2F6DC");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario)
                .ValueGeneratedNever()
                .HasColumnName("id_usuario");
            entity.Property(e => e.Cargo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("cargo");
            entity.Property(e => e.Correo)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("correo");
            entity.Property(e => e.Direccion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("direccion");
            entity.Property(e => e.Documento).HasColumnName("documento");
            entity.Property(e => e.IdAfiliacion).HasColumnName("id_afiliacion");
            entity.Property(e => e.IdNomina).HasColumnName("id_nomina");
            entity.Property(e => e.IdPassword).HasColumnName("Id_password");
            entity.Property(e => e.IdRol).HasColumnName("id_rol");
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono).HasColumnName("telefono");

            entity.HasOne(d => d.IdAfiliacionNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdAfiliacion)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuario_afiliacion");

            entity.HasOne(d => d.IdNominaNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdNomina)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuario_nomina");

            entity.HasOne(d => d.IdPasswordNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdPassword)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_pass");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.IdRol)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_usuario_Rol");
        });

        modelBuilder.Entity<UsuarioRegistro>(entity =>
        {
            entity
                .HasNoKey()
                .ToTable("usuario_registro");

            entity.Property(e => e.IdR).HasColumnName("id_r");
            entity.Property(e => e.IdUser).HasColumnName("id_user");

            entity.HasOne(d => d.IdRNavigation).WithMany()
                .HasForeignKey(d => d.IdR)
                .HasConstraintName("registrouser");

            entity.HasOne(d => d.IdUserNavigation).WithMany()
                .HasForeignKey(d => d.IdUser)
                .HasConstraintName("FK_usuario_registro_usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
