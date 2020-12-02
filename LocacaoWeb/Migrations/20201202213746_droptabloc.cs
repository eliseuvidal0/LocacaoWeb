using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocacaoWeb.Migrations
{
    public partial class droptabloc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacoes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    cliID = table.Column<int>(type: "int", nullable: false),
                    clienteid = table.Column<int>(type: "int", nullable: true),
                    criadoEm = table.Column<DateTime>(type: "datetime2", nullable: false),
                    custoVariavel = table.Column<double>(type: "float", nullable: false),
                    dataEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    devolvido = table.Column<bool>(type: "bit", nullable: false),
                    formaPagamento = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    funID = table.Column<int>(type: "int", nullable: false),
                    funcionarioid = table.Column<int>(type: "int", nullable: true),
                    previsaoEntrega = table.Column<DateTime>(type: "datetime2", nullable: false),
                    totalLocacao = table.Column<double>(type: "float", nullable: false),
                    vecID = table.Column<int>(type: "int", nullable: false),
                    veiculoid = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locacoes", x => x.id);
                    table.ForeignKey(
                        name: "FK_Locacoes_Clientes_clienteid",
                        column: x => x.clienteid,
                        principalTable: "Clientes",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacoes_Funcionarios_funcionarioid",
                        column: x => x.funcionarioid,
                        principalTable: "Funcionarios",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Locacoes_veiculos_veiculoid",
                        column: x => x.veiculoid,
                        principalTable: "veiculos",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_clienteid",
                table: "Locacoes",
                column: "clienteid");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_funcionarioid",
                table: "Locacoes",
                column: "funcionarioid");

            migrationBuilder.CreateIndex(
                name: "IX_Locacoes_veiculoid",
                table: "Locacoes",
                column: "veiculoid");
        }
    }
}
