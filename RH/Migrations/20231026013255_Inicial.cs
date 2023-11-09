using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH.Migrations
{
    /// <inheritdoc />
    public partial class Inicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "usuario",
                columns: table => new
                {
                    id_usuario = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    documento = table.Column<double>(type: "float", nullable: false),
                    direccion = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    telefono = table.Column<double>(type: "float", nullable: false),
                    cargo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    Password = table.Column<string>(type: "varchar(max)", unicode: false, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_usuario", x => x.id_usuario);
                });

            migrationBuilder.CreateTable(
                name: "afiliacion",
                columns: table => new
                {
                    id_afiliacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    Id_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_afiliacion", x => x.id_afiliacion);
                    table.ForeignKey(
                        name: "FK_afiliacion_usuario",
                        column: x => x.Id_user,
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "nomina",
                columns: table => new
                {
                    id_nomina = table.Column<int>(type: "int", nullable: false),
                    id_user = table.Column<int>(type: "int", nullable: true),
                    descuento = table.Column<decimal>(type: "money", nullable: true),
                    Aumento = table.Column<decimal>(type: "money", nullable: true),
                    Can_Horas = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nomina", x => x.id_nomina);
                    table.ForeignKey(
                        name: "FK_nomina_usuario",
                        column: x => x.id_user,
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "registro",
                columns: table => new
                {
                    id_registro = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_user = table.Column<int>(type: "int", nullable: true),
                    fecha_ingreso = table.Column<DateTime>(type: "datetime", nullable: true),
                    fecha_salida = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_registro", x => x.id_registro);
                    table.ForeignKey(
                        name: "FK_registro_usuario",
                        column: x => x.id_user,
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "Rol",
                columns: table => new
                {
                    id_Rol = table.Column<int>(type: "int", nullable: false),
                    Rol = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true),
                    id_user = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rol", x => x.id_Rol);
                    table.ForeignKey(
                        name: "FK_Rol_usuario",
                        column: x => x.id_user,
                        principalTable: "usuario",
                        principalColumn: "id_usuario");
                });

            migrationBuilder.CreateTable(
                name: "estado",
                columns: table => new
                {
                    id_estado = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_nomina = table.Column<int>(type: "int", nullable: true),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_estado", x => x.id_estado);
                    table.ForeignKey(
                        name: "FK_estado_nomina",
                        column: x => x.id_nomina,
                        principalTable: "nomina",
                        principalColumn: "id_nomina");
                });

            migrationBuilder.CreateTable(
                name: "aspirante",
                columns: table => new
                {
                    id_aspirante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    telefono = table.Column<double>(type: "float", nullable: false),
                    curriculum = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    id_regis = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aspirante", x => x.id_aspirante);
                    table.ForeignKey(
                        name: "FK_aspirante_registro",
                        column: x => x.id_regis,
                        principalTable: "registro",
                        principalColumn: "id_registro");
                });

            migrationBuilder.CreateTable(
                name: "permisos",
                columns: table => new
                {
                    id_permiso = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_estado = table.Column<int>(type: "int", nullable: false),
                    descripcion = table.Column<string>(type: "varchar(max)", unicode: false, nullable: false),
                    solicitud = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    fecha_solicfitud = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_inicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    fecha_fin = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permisos", x => x.id_permiso);
                    table.ForeignKey(
                        name: "FK_permisos_estado",
                        column: x => x.id_estado,
                        principalTable: "estado",
                        principalColumn: "id_estado");
                });

            migrationBuilder.CreateTable(
                name: "contratacion",
                columns: table => new
                {
                    id_contratacion = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_asp = table.Column<int>(type: "int", nullable: false),
                    estado = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_contratacion", x => x.id_contratacion);
                    table.ForeignKey(
                        name: "FK_contratacion_aspirante",
                        column: x => x.id_asp,
                        principalTable: "aspirante",
                        principalColumn: "id_aspirante");
                });

            migrationBuilder.CreateIndex(
                name: "IX_afiliacion_Id_user",
                table: "afiliacion",
                column: "Id_user");

            migrationBuilder.CreateIndex(
                name: "IX_aspirante_id_regis",
                table: "aspirante",
                column: "id_regis");

            migrationBuilder.CreateIndex(
                name: "IX_contratacion_id_asp",
                table: "contratacion",
                column: "id_asp");

            migrationBuilder.CreateIndex(
                name: "IX_estado_id_nomina",
                table: "estado",
                column: "id_nomina");

            migrationBuilder.CreateIndex(
                name: "IX_nomina_id_user",
                table: "nomina",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_permisos_id_estado",
                table: "permisos",
                column: "id_estado");

            migrationBuilder.CreateIndex(
                name: "IX_registro_id_user",
                table: "registro",
                column: "id_user");

            migrationBuilder.CreateIndex(
                name: "IX_Rol_id_user",
                table: "Rol",
                column: "id_user");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "afiliacion");

            migrationBuilder.DropTable(
                name: "contratacion");

            migrationBuilder.DropTable(
                name: "permisos");

            migrationBuilder.DropTable(
                name: "Rol");

            migrationBuilder.DropTable(
                name: "aspirante");

            migrationBuilder.DropTable(
                name: "estado");

            migrationBuilder.DropTable(
                name: "registro");

            migrationBuilder.DropTable(
                name: "nomina");

            migrationBuilder.DropTable(
                name: "usuario");
        }
    }
}
