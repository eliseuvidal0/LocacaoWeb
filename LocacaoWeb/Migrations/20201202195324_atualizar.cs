using Microsoft.EntityFrameworkCore.Migrations;

namespace LocacaoWeb.Migrations
{
    public partial class atualizar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Clientes_clienteid",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Funcionarios_funcionarioid",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_veiculos_veiculoid",
                table: "Locacoes");

            migrationBuilder.RenameColumn(
                name: "veiculoid",
                table: "Locacoes",
                newName: "veiculoId");

            migrationBuilder.RenameColumn(
                name: "funcionarioid",
                table: "Locacoes",
                newName: "funcionarioId");

            migrationBuilder.RenameColumn(
                name: "clienteid",
                table: "Locacoes",
                newName: "clienteId");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_veiculoid",
                table: "Locacoes",
                newName: "IX_Locacoes_veiculoId");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_funcionarioid",
                table: "Locacoes",
                newName: "IX_Locacoes_funcionarioId");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_clienteid",
                table: "Locacoes",
                newName: "IX_Locacoes_clienteId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Clientes_clienteId",
                table: "Locacoes",
                column: "clienteId",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Funcionarios_funcionarioId",
                table: "Locacoes",
                column: "funcionarioId",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_veiculos_veiculoId",
                table: "Locacoes",
                column: "veiculoId",
                principalTable: "veiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Clientes_clienteId",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_Funcionarios_funcionarioId",
                table: "Locacoes");

            migrationBuilder.DropForeignKey(
                name: "FK_Locacoes_veiculos_veiculoId",
                table: "Locacoes");

            migrationBuilder.RenameColumn(
                name: "veiculoId",
                table: "Locacoes",
                newName: "veiculoid");

            migrationBuilder.RenameColumn(
                name: "funcionarioId",
                table: "Locacoes",
                newName: "funcionarioid");

            migrationBuilder.RenameColumn(
                name: "clienteId",
                table: "Locacoes",
                newName: "clienteid");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_veiculoId",
                table: "Locacoes",
                newName: "IX_Locacoes_veiculoid");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_funcionarioId",
                table: "Locacoes",
                newName: "IX_Locacoes_funcionarioid");

            migrationBuilder.RenameIndex(
                name: "IX_Locacoes_clienteId",
                table: "Locacoes",
                newName: "IX_Locacoes_clienteid");

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Clientes_clienteid",
                table: "Locacoes",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Funcionarios_funcionarioid",
                table: "Locacoes",
                column: "funcionarioid",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_veiculos_veiculoid",
                table: "Locacoes",
                column: "veiculoid",
                principalTable: "veiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
