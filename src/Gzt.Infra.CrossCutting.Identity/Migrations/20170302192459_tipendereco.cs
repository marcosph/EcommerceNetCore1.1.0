using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gzt.Infra.CrossCutting.Identity.Migrations
{
    public partial class tipendereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioEndereco_Endereco_EnderecoId",
                table: "UsuarioEndereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Enderecos");

            migrationBuilder.RenameColumn(
                name: "EnderecoTipo",
                table: "Enderecos",
                newName: "EnderecoTipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "EnderecoTipos",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EnderecoTipos", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Enderecos_EnderecoTipoId",
                table: "Enderecos",
                column: "EnderecoTipoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Enderecos_EnderecoTipos_EnderecoTipoId",
                table: "Enderecos",
                column: "EnderecoTipoId",
                principalTable: "EnderecoTipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioEndereco_Enderecos_EnderecoId",
                table: "UsuarioEndereco",
                column: "EnderecoId",
                principalTable: "Enderecos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_EnderecoTipos_EnderecoTipoId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioEndereco_Enderecos_EnderecoId",
                table: "UsuarioEndereco");

            migrationBuilder.DropTable(
                name: "EnderecoTipos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.DropIndex(
                name: "IX_Enderecos_EnderecoTipoId",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereco");

            migrationBuilder.RenameColumn(
                name: "EnderecoTipoId",
                table: "Endereco",
                newName: "EnderecoTipo");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioEndereco_Endereco_EnderecoId",
                table: "UsuarioEndereco",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
