using Microsoft.EntityFrameworkCore.Migrations;

namespace LocacaoWeb.Migrations
{
    public partial class validacoes : Migration
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

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                table: "veiculos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "placa",
                table: "veiculos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "modelo",
                table: "veiculos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "marca",
                table: "veiculos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cor",
                table: "veiculos",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "veiculoid",
                table: "Locacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "funcionarioid",
                table: "Locacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "formaPagamento",
                table: "Locacoes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "Locacoes",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Funcionarios",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "telefone",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "cnh",
                table: "Clientes",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.AlterColumn<string>(
                name: "tipo",
                table: "veiculos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "placa",
                table: "veiculos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "modelo",
                table: "veiculos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "marca",
                table: "veiculos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "cor",
                table: "veiculos",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "veiculoid",
                table: "Locacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "funcionarioid",
                table: "Locacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "formaPagamento",
                table: "Locacoes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<int>(
                name: "clienteid",
                table: "Locacoes",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Funcionarios",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "telefone",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "nome",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "email",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "cpf",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<string>(
                name: "cnh",
                table: "Clientes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Clientes_clienteid",
                table: "Locacoes",
                column: "clienteid",
                principalTable: "Clientes",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_Funcionarios_funcionarioid",
                table: "Locacoes",
                column: "funcionarioid",
                principalTable: "Funcionarios",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Locacoes_veiculos_veiculoid",
                table: "Locacoes",
                column: "veiculoid",
                principalTable: "veiculos",
                principalColumn: "id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
