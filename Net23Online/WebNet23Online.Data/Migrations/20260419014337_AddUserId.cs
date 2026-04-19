using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNet23Online.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddUserId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {

            migrationBuilder.DropColumn(
                name: "Name",
                table: "HabitData");

            migrationBuilder.DropColumn(
                name: "Url",
                table: "HabitData");

            migrationBuilder.AddColumn<int>(
                name: "UserId",
                table: "LittleLemonDatas",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_LittleLemonDatas_UserId",
                table: "LittleLemonDatas",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_LittleLemonDatas_Users_UserId",
                table: "LittleLemonDatas",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LittleLemonDatas_Users_UserId",
                table: "LittleLemonDatas");

            migrationBuilder.DropIndex(
                name: "IX_LittleLemonDatas_UserId",
                table: "LittleLemonDatas");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "LittleLemonDatas");

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "HabitData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "HabitData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Url",
                table: "HabitData",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }
    }
}
