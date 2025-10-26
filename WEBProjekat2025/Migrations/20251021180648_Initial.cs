using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WEBProjekat2025.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Aroma",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SlikaURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aroma", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Diskont",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Naziv = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Diskont", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodjac",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodjac", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Pice",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Opis = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    SlikaURL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Proizvedeno = table.Column<DateTime>(type: "datetime2", nullable: false),
                    KategorijaPica = table.Column<int>(type: "int", nullable: false),
                    DiskontId = table.Column<int>(type: "int", nullable: false),
                    ProizvodjacId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pice", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pice_Diskont_DiskontId",
                        column: x => x.DiskontId,
                        principalTable: "Diskont",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Pice_Proizvodjac_ProizvodjacId",
                        column: x => x.ProizvodjacId,
                        principalTable: "Proizvodjac",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Arome_Pice",
                columns: table => new
                {
                    AromaId = table.Column<int>(type: "int", nullable: false),
                    PiceId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Arome_Pice", x => new { x.AromaId, x.PiceId });
                    table.ForeignKey(
                        name: "FK_Arome_Pice_Aroma_AromaId",
                        column: x => x.AromaId,
                        principalTable: "Aroma",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Arome_Pice_Pice_PiceId",
                        column: x => x.PiceId,
                        principalTable: "Pice",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Arome_Pice_PiceId",
                table: "Arome_Pice",
                column: "PiceId");

            migrationBuilder.CreateIndex(
                name: "IX_Pice_DiskontId",
                table: "Pice",
                column: "DiskontId");

            migrationBuilder.CreateIndex(
                name: "IX_Pice_ProizvodjacId",
                table: "Pice",
                column: "ProizvodjacId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Arome_Pice");

            migrationBuilder.DropTable(
                name: "Aroma");

            migrationBuilder.DropTable(
                name: "Pice");

            migrationBuilder.DropTable(
                name: "Diskont");

            migrationBuilder.DropTable(
                name: "Proizvodjac");
        }
    }
}
