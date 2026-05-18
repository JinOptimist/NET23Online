using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNet23Online.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataUserCardForMK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataUserForKorzId = table.Column<int>(type: "int", nullable: false),
                    NumberCard = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BestBeforeDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataUserCardForMK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_DataUserCardForMK_DataUserMK_DataUserForKorzId",
                        column: x => x.DataUserForKorzId,
                        principalTable: "DataUserMK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_DataUserCardForMK_DataUserForKorzId",
                table: "DataUserCardForMK",
                column: "DataUserForKorzId");

            migrationBuilder.CreateIndex(
                name: "IX_DataUserCardForMK_Id",
                table: "DataUserCardForMK",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DataUserCardForMK");
        }
    }
}
