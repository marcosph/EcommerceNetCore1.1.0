using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Gzt.Infra.CrossCutting.Identity.Migrations
{
    public partial class atributosendereco : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookCategory");

            migrationBuilder.DropTable(
                name: "Contracts");

            migrationBuilder.DropTable(
                name: "Book");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Endereco",
                maxLength: 8,
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Bairro",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Complemento",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "EnderecoTipo",
                table: "Endereco",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "Endereco_",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Estado",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "IdentificaoDoEndereco",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Municipio",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "NomeDestinatario",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Numero",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PontoReferencia",
                table: "Endereco",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UF",
                table: "Endereco",
                maxLength: 2,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Bairro",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Complemento",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "EnderecoTipo",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Endereco_",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Estado",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "IdentificaoDoEndereco",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Municipio",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "NomeDestinatario",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "Numero",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "PontoReferencia",
                table: "Endereco");

            migrationBuilder.DropColumn(
                name: "UF",
                table: "Endereco");

            migrationBuilder.AlterColumn<string>(
                name: "CEP",
                table: "Endereco",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 8,
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Book",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Title = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Book", x => x.BookId);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    CategoryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.CategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Contracts",
                columns: table => new
                {
                    ContractId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Charge = table.Column<decimal>(nullable: false),
                    Discriminator = table.Column<string>(nullable: false),
                    Months = table.Column<int>(nullable: false),
                    StartDate = table.Column<DateTime>(nullable: false),
                    DownloadSpeed = table.Column<int>(nullable: true),
                    MobileNumber = table.Column<string>(nullable: true),
                    PackageType = table.Column<int>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Contracts", x => x.ContractId);
                });

            migrationBuilder.CreateTable(
                name: "BookCategory",
                columns: table => new
                {
                    BookId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookCategory", x => new { x.BookId, x.CategoryId });
                    table.ForeignKey(
                        name: "FK_BookCategory_Book_BookId",
                        column: x => x.BookId,
                        principalTable: "Book",
                        principalColumn: "BookId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BookCategory_Category_CategoryId",
                        column: x => x.CategoryId,
                        principalTable: "Category",
                        principalColumn: "CategoryId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookCategory_CategoryId",
                table: "BookCategory",
                column: "CategoryId");
        }
    }
}
