using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RH.Migrations
{
    /// <inheritdoc />
    public partial class migracion3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rol_usuario",
                table: "Rol");

            migrationBuilder.DropIndex(
                name: "IX_Rol_id_user",
                table: "Rol");

            migrationBuilder.DropColumn(
                name: "id_user",
                table: "Rol");

            migrationBuilder.AddColumn<int>(
                name: "IdUserNavigationIdRol",
                table: "usuario",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "id_Rol",
                table: "usuario",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_usuario_IdUserNavigationIdRol",
                table: "usuario",
                column: "IdUserNavigationIdRol");

            migrationBuilder.AddForeignKey(
                name: "FK_usuario_Rol_IdUserNavigationIdRol",
                table: "usuario",
                column: "IdUserNavigationIdRol",
                principalTable: "Rol",
                principalColumn: "id_Rol");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_usuario_Rol_IdUserNavigationIdRol",
                table: "usuario");

            migrationBuilder.DropIndex(
                name: "IX_usuario_IdUserNavigationIdRol",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "IdUserNavigationIdRol",
                table: "usuario");

            migrationBuilder.DropColumn(
                name: "id_Rol",
                table: "usuario");

            migrationBuilder.AddColumn<int>(
                name: "id_user",
                table: "Rol",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Rol_id_user",
                table: "Rol",
                column: "id_user");

            migrationBuilder.AddForeignKey(
                name: "FK_Rol_usuario",
                table: "Rol",
                column: "id_user",
                principalTable: "usuario",
                principalColumn: "id_usuario");
        }
    }
}
