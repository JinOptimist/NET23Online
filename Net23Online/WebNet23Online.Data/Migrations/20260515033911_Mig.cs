using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNet23Online.Data.Migrations
{
    /// <inheritdoc />
    public partial class Mig : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ConcertMK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LlocationId = table.Column<int>(type: "int", nullable: false),
                    DataUserForKorzId = table.Column<int>(type: "int", nullable: false),
                    DataConcert = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ConcertMK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ConcertMK_DataUserMK_DataUserForKorzId",
                        column: x => x.DataUserForKorzId,
                        principalTable: "DataUserMK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ConcertMK_LocationMK_LlocationId",
                        column: x => x.LlocationId,
                        principalTable: "LocationMK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ConcertMK_DataUserForKorzId",
                table: "ConcertMK",
                column: "DataUserForKorzId");

            migrationBuilder.CreateIndex(
                name: "IX_ConcertMK_Id",
                table: "ConcertMK",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ConcertMK_LlocationId",
                table: "ConcertMK",
                column: "LlocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ConcertMK");
        }
    }
}
