using Microsoft.EntityFrameworkCore.Migrations;

namespace PinguCheckIn.Migrations
{
    public partial class ReservaRemoveFk2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Cliente_ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_ClienteIdCliente",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "ClienteIdCliente",
                table: "Reserva");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ClienteIdCliente",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_ClienteIdCliente",
                table: "Reserva",
                column: "ClienteIdCliente");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Cliente_ClienteIdCliente",
                table: "Reserva",
                column: "ClienteIdCliente",
                principalTable: "Cliente",
                principalColumn: "IdCliente",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
