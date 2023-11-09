using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH.Migrations
{
    /// <inheritdoc />
    public partial class Microservice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_contratacion_aspirante",
                table: "contratacion");

            migrationBuilder.DropForeignKey(
                name: "FK_usuario_Rol_IdUserNavigationIdRol",
                table: "usuario");

            migrationBuilder.DropTable(
                name: "aspirante");

            migrationBuilder.DropPrimaryKey(
                name: "PK_contratacion",
                table: "contratacion");

            migrationBuilder.DropIndex(
                name: "IX_contratacion_id_asp",
                table: "contratacion");

            migrationBuilder.DropColumn(
                name: "id_asp",
                table: "contratacion");

            migrationBuilder.RenameColumn(
                name: "IdUserNavigationIdRol",
                table: "usuario",
                newName: "Idcontratacion");

            migrationBuilder.AddColumn<byte[]>(
                name: "Curriculum",
                table: "usuario",
                type: "image",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK__contrata__CD5220878EF9ADB0",
                table: "contratacion",
                column: "id_contratacion");

            migrationBuilder.CreateIndex(
                name: "IX_usuario_id_Rol",
                table: "usuario",
                column: "id_Rol");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_Rol_IdUserNavigationIdRol",
                table: "usuario",
                column: "id_Rol",
                principalTable: "Rol",
                principalColumn: "id_Rol");

            migrationBuilder.AddForeignKey(
                name: "usercont",
                table: "usuario",
                column: "Idcontratacion",
                principalTable: "contratacion",
                principalColumn: "id_contratacion");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_Rol_IdUserNavigationIdRol",
                table: "usuario");

            migrationBuilder.DropForeignKey(
                name: "usercont",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_id_Rol",
                table: "usuario");

            migrationBuilder.DropPrimaryKey(
                name: "PK__contrata__CD5220878EF9ADB0",
                table: "contratacion");

            migrationBuilder.DropColumn(
                name: "Curriculum",
                table: "usuario");

            migrationBuilder.RenameColumn(
                name: "Idcontratacion",
                table: "usuario",
                newName: "IdUserNavigationIdRol");

            migrationBuilder.AddColumn<int>(
                name: "id_asp",
                table: "contratacion",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_contratacion",
                table: "contratacion",
                column: "id_contratacion");

            migrationBuilder.CreateTable(
                name: "aspirante",
                columns: table => new
                {
                    id_aspirante = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    id_regis = table.Column<int>(type: "int", nullable: false),
                    correo = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    curriculum = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    nombre = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    telefono = table.Column<double>(type: "float", nullable: false)
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

            migrationBuilder.CreateIndex(
                name: "IX_contratacion_id_asp",
                table: "contratacion",
                column: "id_asp");

            migrationBuilder.CreateIndex(
                name: "IX_aspirante_id_regis",
                table: "aspirante",
                column: "id_regis");

            migrationBuilder.AddForeignKey(
                name: "FK_contratacion_aspirante",
                table: "contratacion",
                column: "id_asp",
                principalTable: "aspirante",
                principalColumn: "id_aspirante");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_Rol_IdUserNavigationIdRol",
                table: "usuario",
                column: "IdUserNavigationIdRol",
                principalTable: "Rol",
                principalColumn: "id_Rol");
        }
    }
}
