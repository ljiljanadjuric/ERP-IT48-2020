using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdavnicaObuce.Migrations
{
    /// <inheritdoc />
    public partial class DodateStavkePorudzbine : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "StavkePorudzbine",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Kolicina = table.Column<int>(type: "int", nullable: false),
                    IdPorudzbine = table.Column<int>(type: "int", nullable: false),
                    IdProizvoda = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StavkePorudzbine", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StavkePorudzbine_Porudzbine_IdPorudzbine",
                        column: x => x.IdPorudzbine,
                        principalTable: "Porudzbine",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StavkePorudzbine_Proizvodi_IdProizvoda",
                        column: x => x.IdProizvoda,
                        principalTable: "Proizvodi",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_StavkePorudzbine_IdPorudzbine",
                table: "StavkePorudzbine",
                column: "IdPorudzbine");

            migrationBuilder.CreateIndex(
                name: "IX_StavkePorudzbine_IdProizvoda",
                table: "StavkePorudzbine",
                column: "IdProizvoda");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "StavkePorudzbine");
        }
    }
}
