using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace LocacaoWeb.Migrations
{
    public partial class createtabloc : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Locacoes",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    clienteid = table.Column<int>(nullable: true),
                    veiculoid = table.Column<int>(nullable: true),
                    funcionarioid = table.Column<int>(nullable: true),
                    formaPagamento = table.Column<string>(nullable: true),
                    totalLocacao = table.Column<double>(nullable: false),
                    previsaoEntrega = table.Column<DateTime>(nullable: false),
                    criadoEm = table.Column<DateTime>(nullable: false),
                    dataEntrega = table.Column<DateTime>(nullable: false),
                    custoVariavel = table.Column<double>(nullable: false),
                    devolvido = table.Column<bool>(nullable: false),
                    cliID = table.Column<int>(nullable: false),
                    vecID = table.Column<int>(nullable: false),
                    funID = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Locacoes");
        }
    }
}
