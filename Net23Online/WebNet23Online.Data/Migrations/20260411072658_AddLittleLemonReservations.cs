using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNet23Online.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddLittleLemonReservations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "littleLemonDatas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberOfGuests = table.Column<int>(type: "int", nullable: false),
                    SeatingPreference = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AvailableTimesOnly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ReservationDateOnly = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Occasion = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserComments = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_littleLemonDatas", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "littleLemonDatas");
        }
    }
}
