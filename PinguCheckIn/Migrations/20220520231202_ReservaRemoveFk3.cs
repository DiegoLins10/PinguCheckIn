using Microsoft.EntityFrameworkCore.Migrations;

namespace PinguCheckIn.Migrations
{
    public partial class ReservaRemoveFk3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Usuario_UsuarioIdUsuario",
                table: "Cliente");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_UsuarioIdUsuario",
                table: "Cliente");

            migrationBuilder.DropColumn(
                name: "UsuarioIdUsuario",
                table: "Cliente");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "UsuarioIdUsuario",
                table: "Cliente",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_UsuarioIdUsuario",
                table: "Cliente",
                column: "UsuarioIdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Usuario_UsuarioIdUsuario",
                table: "Cliente",
                column: "UsuarioIdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
