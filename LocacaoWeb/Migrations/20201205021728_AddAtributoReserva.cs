using Microsoft.EntityFrameworkCore.Migrations;

namespace LocacaoWeb.Migrations
{
    public partial class AddAtributoReserva : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "reservado",
                table: "veiculos",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "reservado",
                table: "veiculos");
        }
    }
}
