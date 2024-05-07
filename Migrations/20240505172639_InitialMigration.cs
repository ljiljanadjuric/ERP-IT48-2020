using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdavnicaObuce.Migrations
{
    /// <inheritdoc />
    public partial class InitialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Dobavljaci",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Kontakt = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Dobavljaci", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Korisnici",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    KorisnickoIme = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Sifra = table.Column<string>(type: "nvarchar(300)", maxLength: 300, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Ime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Prezime = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Adresa = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    BrojTelefona = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Tip = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Korisnici", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Proizvodi",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Ime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Cena = table.Column<double>(type: "float", nullable: false),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    Boja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Brend = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Proizvodi", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Porudzbine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    VremePorudzbe = table.Column<DateTime>(type: "datetime2", nullable: false),
                    VremeDostave = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CenaPorudzbine = table.Column<double>(type: "float", nullable: false),
                    IdZaposlenog = table.Column<int>(type: "int", nullable: false),
                    IdDobavljaca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Porudzbine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Porudzbine_Dobavljaci_IdDobavljaca",
                        column: x => x.IdDobavljaca,
                        principalTable: "Dobavljaci",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Porudzbine_Korisnici_IdZaposlenog",
                        column: x => x.IdZaposlenog,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Prodaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    VremeProdaje = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CenaProdaje = table.Column<double>(type: "float", nullable: false),
                    NacinPlacanja = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IdKupca = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prodaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prodaje_Korisnici_IdKupca",
                        column: x => x.IdKupca,
                        principalTable: "Korisnici",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "StavkeProdaje",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    IdProizvoda = table.Column<int>(type: "int", nullable: false),
                    IdProdaje = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkeProdaje", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkeProdaje_Prodaje_IdProdaje",
                        column: x => x.IdProdaje,
                        principalTable: "Prodaje",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_StavkeProdaje_Proizvodi_IdProizvoda",
                        column: x => x.IdProizvoda,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_Email",
                table: "Korisnici",
                column: "Email",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Korisnici_KorisnickoIme",
                table: "Korisnici",
                column: "KorisnickoIme",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbine_IdDobavljaca",
                table: "Porudzbine",
                column: "IdDobavljaca");

            migrationBuilder.CreateIndex(
                name: "IX_Porudzbine_IdZaposlenog",
                table: "Porudzbine",
                column: "IdZaposlenog");

            migrationBuilder.CreateIndex(
                name: "IX_Prodaje_IdKupca",
                table: "Prodaje",
                column: "IdKupca");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeProdaje_IdProdaje",
                table: "StavkeProdaje",
                column: "IdProdaje");

            migrationBuilder.CreateIndex(
                name: "IX_StavkeProdaje_IdProizvoda",
                table: "StavkeProdaje",
                column: "IdProizvoda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Porudzbine");

            migrationBuilder.DropTable(
                name: "StavkeProdaje");

            migrationBuilder.DropTable(
                name: "Dobavljaci");

            migrationBuilder.DropTable(
                name: "Prodaje");

            migrationBuilder.DropTable(
                name: "Proizvodi");

            migrationBuilder.DropTable(
                name: "Korisnici");
        }
    }
}
