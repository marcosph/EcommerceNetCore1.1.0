using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gzt.Infra.CrossCutting.Identity.Migrations
{
    public partial class tipotel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefones_User_UserId",
                table: "Telefones");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telefones",
                table: "Telefones");

            migrationBuilder.RenameTable(
                name: "Telefones",
                newName: "Telefone");

            migrationBuilder.RenameColumn(
                name: "TelefoneTipo",
                table: "Telefone",
                newName: "TelefoneTipoId");

            migrationBuilder.RenameIndex(
                name: "IX_Telefones_UserId",
                table: "Telefone",
                newName: "IX_Telefone_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telefone",
                table: "Telefone",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "TelefoneTipo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Descricao = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TelefoneTipo", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefone_TelefoneTipoId",
                table: "Telefone",
                column: "TelefoneTipoId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_TelefoneTipo_TelefoneTipoId",
                table: "Telefone",
                column: "TelefoneTipoId",
                principalTable: "TelefoneTipo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Telefone_User_UserId",
                table: "Telefone",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_TelefoneTipo_TelefoneTipoId",
                table: "Telefone");

            migrationBuilder.DropForeignKey(
                name: "FK_Telefone_User_UserId",
                table: "Telefone");

            migrationBuilder.DropTable(
                name: "TelefoneTipo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Telefone",
                table: "Telefone");

            migrationBuilder.DropIndex(
                name: "IX_Telefone_TelefoneTipoId",
                table: "Telefone");

            migrationBuilder.RenameTable(
                name: "Telefone",
                newName: "Telefones");

            migrationBuilder.RenameColumn(
                name: "TelefoneTipoId",
                table: "Telefones",
                newName: "TelefoneTipo");

            migrationBuilder.RenameIndex(
                name: "IX_Telefone_UserId",
                table: "Telefones",
                newName: "IX_Telefones_UserId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Telefones",
                table: "Telefones",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Telefones_User_UserId",
                table: "Telefones",
                column: "UserId",
                principalTable: "User",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
