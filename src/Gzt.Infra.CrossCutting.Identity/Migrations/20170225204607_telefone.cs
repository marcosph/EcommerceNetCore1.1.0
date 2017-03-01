using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gzt.Infra.CrossCutting.Identity.Migrations
{
    public partial class telefone : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DataNascimento",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Genero",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "InscricaoEstadual",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Isento",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeFantasia",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "OptantePeloSimples",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "RazaoSocial",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Site",
                table: "User",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Telefones",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Numero = table.Column<string>(nullable: true),
                    TelefoneTipo = table.Column<int>(nullable: false),
                    UserId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Telefones", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Telefones_User_UserId",
                        column: x => x.UserId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Telefones_UserId",
                table: "Telefones",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Telefones");

            migrationBuilder.DropColumn(
                name: "DataNascimento",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Genero",
                table: "User");

            migrationBuilder.DropColumn(
                name: "InscricaoEstadual",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Isento",
                table: "User");

            migrationBuilder.DropColumn(
                name: "NomeFantasia",
                table: "User");

            migrationBuilder.DropColumn(
                name: "OptantePeloSimples",
                table: "User");

            migrationBuilder.DropColumn(
                name: "RazaoSocial",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Site",
                table: "User");
        }
    }
}
