using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SlayTheSpire2RelicsMinimalApi.Migrations
{
    /// <inheritdoc />
    public partial class AddRelicDescriptionAndCharacters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Characters",
                table: "Relics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Relics",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Characters",
                table: "Relics");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Relics");
        }
    }
}
