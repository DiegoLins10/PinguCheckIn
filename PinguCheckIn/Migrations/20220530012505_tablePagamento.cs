using Microsoft.EntityFrameworkCore.Migrations;

namespace PinguCheckIn.Migrations
{
    public partial class tablePagamento : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdPagamento",
                table: "Reserva",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Pagamentos",
                columns: table => new
                {
                    IdPagamento = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCartao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NumeroCartao = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Dataexp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cvv = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Aceito = table.Column<bool>(type: "bit", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sobrenome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco2 = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TipoPagamento = table.Column<int>(type: "int", nullable: false),
                    IdCliente = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pagamentos", x => x.IdPagamento);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Pagamentos");

            migrationBuilder.DropColumn(
                name: "IdPagamento",
                table: "Reserva");
        }
    }
}
