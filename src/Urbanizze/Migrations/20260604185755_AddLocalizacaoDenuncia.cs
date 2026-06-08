using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Urbanizze.Migrations
{
    /// <inheritdoc />
    public partial class AddLocalizacaoDenuncia : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "localizacao",
                table: "DENUNCIA",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "localizacao",
                table: "DENUNCIA");
        }
    }
}
