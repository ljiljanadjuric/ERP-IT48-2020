using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProdavnicaObuce.Migrations
{
    /// <inheritdoc />
    public partial class Prodaja_Placanje : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Placeno",
                table: "Prodaje",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Placeno",
                table: "Prodaje");
        }
    }
}
