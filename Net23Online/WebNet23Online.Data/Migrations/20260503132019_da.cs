using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNet23Online.Data.Migrations
{
    /// <inheritdoc />
    public partial class da : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "TicketMK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumberTicket = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DateStatrConsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateFinishConsert = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DataUserForMaksKorzId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TicketMK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TicketMK_DataUserMK_DataUserForMaksKorzId",
                        column: x => x.DataUserForMaksKorzId,
                        principalTable: "DataUserMK",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LocationMK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameStadium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    TicketForMKId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationMK", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LocationMK_TicketMK_TicketForMKId",
                        column: x => x.TicketForMKId,
                        principalTable: "TicketMK",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationMK_Id",
                table: "LocationMK",
                column: "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_LocationMK_TicketForMKId",
                table: "LocationMK",
                column: "TicketForMKId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMK_DataUserForMaksKorzId",
                table: "TicketMK",
                column: "DataUserForMaksKorzId");

            migrationBuilder.CreateIndex(
                name: "IX_TicketMK_Id",
                table: "TicketMK",
                column: "Id",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationMK");

            migrationBuilder.DropTable(
                name: "TicketMK");
        }
    }
}
