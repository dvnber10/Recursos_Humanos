﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RH.Models;

#nullable disable

namespace RH.Migrations
{
    [DbContext(typeof(RecursosHumanosContext))]
    partial class RecursosHumanosContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.13")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("RH.Models.Afiliacion", b =>
                {
                    b.Property<int>("IdAfiliacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_afiliacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAfiliacion"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("descripcion");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("Id_user");

                    b.HasKey("IdAfiliacion");

                    b.HasIndex("IdUser");

                    b.ToTable("afiliacion", (string)null);
                });

            modelBuilder.Entity("RH.Models.Aspirante", b =>
                {
                    b.Property<int>("IdAspirante")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_aspirante");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdAspirante"));

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("correo");

                    b.Property<string>("Curriculum")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("curriculum");

                    b.Property<int>("IdRegis")
                        .HasColumnType("int")
                        .HasColumnName("id_regis");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<double>("Telefono")
                        .HasColumnType("float")
                        .HasColumnName("telefono");

                    b.HasKey("IdAspirante");

                    b.HasIndex("IdRegis");

                    b.ToTable("aspirante", (string)null);
                });

            modelBuilder.Entity("RH.Models.Contratacion", b =>
                {
                    b.Property<int>("IdContratacion")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_contratacion");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdContratacion"));

                    b.Property<string>("Estado")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("estado");

                    b.Property<int>("IdAsp")
                        .HasColumnType("int")
                        .HasColumnName("id_asp");

                    b.HasKey("IdContratacion");

                    b.HasIndex("IdAsp");

                    b.ToTable("contratacion", (string)null);
                });

            modelBuilder.Entity("RH.Models.Estado", b =>
                {
                    b.Property<int>("IdEstado")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_estado");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdEstado"));

                    b.Property<string>("Estado1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("estado");

                    b.Property<int?>("IdNomina")
                        .HasColumnType("int")
                        .HasColumnName("id_nomina");

                    b.HasKey("IdEstado");

                    b.HasIndex("IdNomina");

                    b.ToTable("estado", (string)null);
                });

            modelBuilder.Entity("RH.Models.Nomina", b =>
                {
                    b.Property<int>("IdNomina")
                        .HasColumnType("int")
                        .HasColumnName("id_nomina");

                    b.Property<decimal?>("Aumento")
                        .HasColumnType("money");

                    b.Property<int?>("CanHoras")
                        .HasColumnType("int")
                        .HasColumnName("Can_Horas");

                    b.Property<decimal?>("Descuento")
                        .HasColumnType("money")
                        .HasColumnName("descuento");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.HasKey("IdNomina");

                    b.HasIndex("IdUser");

                    b.ToTable("nomina", (string)null);
                });

            modelBuilder.Entity("RH.Models.Permiso", b =>
                {
                    b.Property<int>("IdPermiso")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_permiso");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdPermiso"));

                    b.Property<string>("Descripcion")
                        .IsRequired()
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)")
                        .HasColumnName("descripcion");

                    b.Property<DateTime>("FechaFin")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_fin");

                    b.Property<DateTime>("FechaInicio")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_inicio");

                    b.Property<DateTime>("FechaSolicfitud")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_solicfitud");

                    b.Property<int>("IdEstado")
                        .HasColumnType("int")
                        .HasColumnName("id_estado");

                    b.Property<string>("Solicitud")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("solicitud");

                    b.HasKey("IdPermiso");

                    b.HasIndex("IdEstado");

                    b.ToTable("permisos", (string)null);
                });

            modelBuilder.Entity("RH.Models.Registro", b =>
                {
                    b.Property<int>("IdRegistro")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_registro");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdRegistro"));

                    b.Property<DateTime?>("FechaIngreso")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_ingreso");

                    b.Property<DateTime?>("FechaSalida")
                        .HasColumnType("datetime")
                        .HasColumnName("fecha_salida");

                    b.Property<int?>("IdUser")
                        .HasColumnType("int")
                        .HasColumnName("id_user");

                    b.HasKey("IdRegistro");

                    b.HasIndex("IdUser");

                    b.ToTable("registro", (string)null);
                });

            modelBuilder.Entity("RH.Models.Rol", b =>
                {
                    b.Property<int>("IdRol")
                        .HasColumnType("int")
                        .HasColumnName("id_Rol");

                    b.Property<string>("Rol1")
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("Rol");

                    b.HasKey("IdRol");

                    b.ToTable("Rol", (string)null);
                });

            modelBuilder.Entity("RH.Models.Usuario", b =>
                {
                    b.Property<int>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("id_usuario");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("IdUsuario"));

                    b.Property<string>("Cargo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("cargo");

                    b.Property<string>("Contraseña")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("Correo")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("correo");

                    b.Property<string>("Direccion")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("direccion");

                    b.Property<double>("Documento")
                        .HasColumnType("float")
                        .HasColumnName("documento");

                    b.Property<int?>("IdUserNavigationIdRol")
                        .HasColumnType("int");

                    b.Property<string>("Nombre")
                        .IsRequired()
                        .HasMaxLength(50)
                        .IsUnicode(false)
                        .HasColumnType("varchar(50)")
                        .HasColumnName("nombre");

                    b.Property<double>("Telefono")
                        .HasColumnType("float")
                        .HasColumnName("telefono");

                    b.Property<int>("id_Rol")
                        .HasColumnType("int");

                    b.HasKey("IdUsuario");

                    b.HasIndex("IdUserNavigationIdRol");

                    b.ToTable("usuario", (string)null);
                });

            modelBuilder.Entity("RH.Models.Afiliacion", b =>
                {
                    b.HasOne("RH.Models.Usuario", "IdUserNavigation")
                        .WithMany("Afiliacions")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_afiliacion_usuario");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("RH.Models.Aspirante", b =>
                {
                    b.HasOne("RH.Models.Registro", "IdRegisNavigation")
                        .WithMany("Aspirantes")
                        .HasForeignKey("IdRegis")
                        .IsRequired()
                        .HasConstraintName("FK_aspirante_registro");

                    b.Navigation("IdRegisNavigation");
                });

            modelBuilder.Entity("RH.Models.Contratacion", b =>
                {
                    b.HasOne("RH.Models.Aspirante", "IdAspNavigation")
                        .WithMany("Contratacions")
                        .HasForeignKey("IdAsp")
                        .IsRequired()
                        .HasConstraintName("FK_contratacion_aspirante");

                    b.Navigation("IdAspNavigation");
                });

            modelBuilder.Entity("RH.Models.Estado", b =>
                {
                    b.HasOne("RH.Models.Nomina", "IdNominaNavigation")
                        .WithMany("Estados")
                        .HasForeignKey("IdNomina")
                        .HasConstraintName("FK_estado_nomina");

                    b.Navigation("IdNominaNavigation");
                });

            modelBuilder.Entity("RH.Models.Nomina", b =>
                {
                    b.HasOne("RH.Models.Usuario", "IdUserNavigation")
                        .WithMany("Nominas")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_nomina_usuario");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("RH.Models.Permiso", b =>
                {
                    b.HasOne("RH.Models.Estado", "IdEstadoNavigation")
                        .WithMany("Permisos")
                        .HasForeignKey("IdEstado")
                        .IsRequired()
                        .HasConstraintName("FK_permisos_estado");

                    b.Navigation("IdEstadoNavigation");
                });

            modelBuilder.Entity("RH.Models.Registro", b =>
                {
                    b.HasOne("RH.Models.Usuario", "IdUserNavigation")
                        .WithMany("Registros")
                        .HasForeignKey("IdUser")
                        .HasConstraintName("FK_registro_usuario");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("RH.Models.Usuario", b =>
                {
                    b.HasOne("RH.Models.Rol", "IdUserNavigation")
                        .WithMany()
                        .HasForeignKey("IdUserNavigationIdRol");

                    b.Navigation("IdUserNavigation");
                });

            modelBuilder.Entity("RH.Models.Aspirante", b =>
                {
                    b.Navigation("Contratacions");
                });

            modelBuilder.Entity("RH.Models.Estado", b =>
                {
                    b.Navigation("Permisos");
                });

            modelBuilder.Entity("RH.Models.Nomina", b =>
                {
                    b.Navigation("Estados");
                });

            modelBuilder.Entity("RH.Models.Registro", b =>
                {
                    b.Navigation("Aspirantes");
                });

            modelBuilder.Entity("RH.Models.Usuario", b =>
                {
                    b.Navigation("Afiliacions");

                    b.Navigation("Nominas");

                    b.Navigation("Registros");
                });
#pragma warning restore 612, 618
        }
    }
}
