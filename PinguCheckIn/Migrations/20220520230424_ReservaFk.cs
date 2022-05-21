using Microsoft.EntityFrameworkCore.Migrations;

namespace PinguCheckIn.Migrations
{
    public partial class ReservaFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "QuartoIdQuarto",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteIdCliente",
                table: "Reserva",
                column: "ClienteIdCliente");

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_QuartoIdQuarto",
                table: "Reserva",
                column: "QuartoIdQuarto");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteIdCliente",
                table: "Reserva",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Quarto_QuartoIdQuarto",
                table: "Reserva",
                column: "QuartoIdQuarto",
                principalTable: "Quarto",
                principalColumn: "IdQuarto",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Quarto_QuartoIdQuarto",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_QuartoIdQuarto",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "QuartoIdQuarto",
                table: "Reserva");
        }
    }
}
