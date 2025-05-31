using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdavnicaObuce.Migrations
{
    /// <inheritdoc />
    public partial class Slika_Proizvod : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Slika",
                table: "Proizvodi",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Slika",
                table: "Proizvodi");
        }
    }
}
