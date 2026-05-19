using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNet23Online.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddColumnCreatorIdInJdmCarsTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CreatorId",
                table: "JdmCars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_JdmCars_CreatorId",
                table: "JdmCars",
                column: "CreatorId");

            migrationBuilder.AddForeignKey(
                name: "FK_JdmCars_Users_CreatorId",
                table: "JdmCars",
                column: "CreatorId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_JdmCars_Users_CreatorId",
                table: "JdmCars");

            migrationBuilder.DropIndex(
                name: "IX_JdmCars_CreatorId",
                table: "JdmCars");

            migrationBuilder.DropColumn(
                name: "CreatorId",
                table: "JdmCars");
        }
    }
}
