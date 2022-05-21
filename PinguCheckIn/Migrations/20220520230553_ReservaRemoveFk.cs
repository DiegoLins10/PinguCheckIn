using Microsoft.EntityFrameworkCore.Migrations;

namespace PinguCheckIn.Migrations
{
    public partial class ReservaRemoveFk : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Reserva_Quarto_QuartoIdQuarto",
                table: "Reserva");

            migrationBuilder.DropIndex(
                name: "IX_Reserva_QuartoIdQuarto",
                table: "Reserva");

            migrationBuilder.DropColumn(
                name: "QuartoIdQuarto",
                table: "Reserva");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuartoIdQuarto",
                table: "Reserva",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Reserva_QuartoIdQuarto",
                table: "Reserva",
                column: "QuartoIdQuarto");

            migrationBuilder.AddForeignKey(
                name: "FK_Reserva_Quarto_QuartoIdQuarto",
                table: "Reserva",
                column: "QuartoIdQuarto",
                principalTable: "Quarto",
                principalColumn: "IdQuarto",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
