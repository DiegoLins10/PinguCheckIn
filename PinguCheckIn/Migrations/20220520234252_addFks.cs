using Microsoft.EntityFrameworkCore.Migrations;

namespace PinguCheckIn.Migrations
{
    public partial class addFks : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Reserva_IdQuarto",
                table: "Reserva",
                column: "IdQuarto");

            migrationBuilder.CreateIndex(
                name: "IX_Cliente_IdUsuario",
                table: "Cliente",
                column: "IdUsuario");

            migrationBuilder.AddForeignKey(
                name: "FK_Cliente_Usuario_IdUsuario",
                table: "Cliente",
                column: "IdUsuario",
                principalTable: "Usuario",
                principalColumn: "IdUsuario",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Quarto_IdQuarto",
                table: "Reserva",
                column: "IdQuarto",
                principalTable: "Quarto",
                principalColumn: "IdQuarto",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cliente_Usuario_IdUsuario",
                table: "Cliente");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Quarto_IdQuarto",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_IdQuarto",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Cliente_IdUsuario",
                table: "Cliente");
        }
    }
}
