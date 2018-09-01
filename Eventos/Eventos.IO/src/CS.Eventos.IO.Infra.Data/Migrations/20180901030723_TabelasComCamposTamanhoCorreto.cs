using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace CS.Eventos.IO.Infra.Data.Migrations
{
    public partial class TabelasComCamposTamanhoCorreto : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Eventos_EventoId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_EventoId",
                table: "Enderecos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Organizadores",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Organizadores",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Organizadores",
                type: "varchar(11)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Enderecos",
                type: "varchar(20)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<Guid>(
                name: "EventoId",
                table: "Enderecos",
                nullable: false,
                oldClrType: typeof(Guid),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Enderecos",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Enderecos",
                type: "varchar(100)",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Enderecos",
                type: "varchar(100)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Enderecos",
                type: "varchar(8)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Enderecos",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categorias",
                type: "varchar(150)",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EventoId",
                table: "Enderecos",
                column: "EventoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Eventos_EventoId",
                table: "Enderecos",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_Eventos_EventoId",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_EventoId",
                table: "Enderecos");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Organizadores",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Organizadores",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "CPF",
                table: "Organizadores",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(11)");

            migrationBuilder.AlterColumn<string>(
                name: "Logradouro",
                table: "Enderecos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(20)");

            migrationBuilder.AlterColumn<Guid>(
                name: "EventoId",
                table: "Enderecos",
                nullable: true,
                oldClrType: typeof(Guid));

            migrationBuilder.AlterColumn<string>(
                name: "Estado",
                table: "Enderecos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "Complemento",
                table: "Enderecos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Cidade",
                table: "Enderecos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(100)");

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Enderecos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(8)");

            migrationBuilder.AlterColumn<string>(
                name: "Bairro",
                table: "Enderecos",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.AlterColumn<string>(
                name: "Nome",
                table: "Categorias",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(150)");

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EventoId",
                table: "Enderecos",
                column: "EventoId",
                unique: true,
                filter: "[EventoId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_Eventos_EventoId",
                table: "Enderecos",
                column: "EventoId",
                principalTable: "Eventos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
