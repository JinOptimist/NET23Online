using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNet23Online.Data.Migrations
{
    /// <inheritdoc />
    public partial class Init6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DataUserMK_LastName",
                table: "DataUserMK");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "DataUserMK",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_DataUserMK_Id",
                table: "DataUserMK",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_DataUserMK_Id",
                table: "DataUserMK");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "DataUserMK",
                type: "nvarchar(450)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_DataUserMK_LastName",
                table: "DataUserMK",
                column: "LastName",
                unique: true);
        }
    }
}
