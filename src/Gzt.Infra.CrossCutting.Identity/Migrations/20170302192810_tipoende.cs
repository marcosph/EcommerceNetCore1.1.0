using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Gzt.Infra.CrossCutting.Identity.Migrations
{
    public partial class tipoende : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Enderecos_EnderecoTipos_EnderecoTipoId",
                table: "Enderecos");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioEndereco_Enderecos_EnderecoId",
                table: "UsuarioEndereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoTipos",
                table: "EnderecoTipos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos");

            migrationBuilder.RenameTable(
                name: "EnderecoTipos",
                newName: "EnderecoTipo");

            migrationBuilder.RenameTable(
                name: "Enderecos",
                newName: "Endereco");

            migrationBuilder.RenameIndex(
                name: "IX_Enderecos_EnderecoTipoId",
                table: "Endereco",
                newName: "IX_Endereco_EnderecoTipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoTipo",
                table: "EnderecoTipo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Endereco_EnderecoTipo_EnderecoTipoId",
                table: "Endereco",
                column: "EnderecoTipoId",
                principalTable: "EnderecoTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_UsuarioEndereco_Endereco_EnderecoId",
                table: "UsuarioEndereco",
                column: "EnderecoId",
                principalTable: "Endereco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Endereco_EnderecoTipo_EnderecoTipoId",
                table: "Endereco");

            migrationBuilder.DropForeignKey(
                name: "FK_UsuarioEndereco_Endereco_EnderecoId",
                table: "UsuarioEndereco");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EnderecoTipo",
                table: "EnderecoTipo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Endereco",
                table: "Endereco");

            migrationBuilder.RenameTable(
                name: "EnderecoTipo",
                newName: "EnderecoTipos");

            migrationBuilder.RenameTable(
                name: "Endereco",
                newName: "Enderecos");

            migrationBuilder.RenameIndex(
                name: "IX_Endereco_EnderecoTipoId",
                table: "Enderecos",
                newName: "IX_Enderecos_EnderecoTipoId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EnderecoTipos",
                table: "EnderecoTipos",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Enderecos",
                table: "Enderecos",
                column: "Id");

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
    }
}
