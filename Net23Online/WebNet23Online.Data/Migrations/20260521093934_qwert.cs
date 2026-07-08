using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNet23Online.Data.Migrations
{
    /// <inheritdoc />
    public partial class qwert : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "DataUserMK",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataUserMK", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MKDataUserCardFor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataUserForKorzId = table.Column<int>(type: "int", nullable: false),
                    NumberCard = table.Column<string>(type: "nvarchar(16)", maxLength: 16, nullable: false),
                    CVV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    BestBeforeDate = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MKDataUserCardFor", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MKDataUserCardFor_DataUserMK_DataUserForKorzId",
                        column: x => x.DataUserForKorzId,
                        principalTable: "DataUserMK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MKTicket",
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
                    table.PrimaryKey("PK_MKTicket", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MKTicket_DataUserMK_DataUserForMaksKorzId",
                        column: x => x.DataUserForMaksKorzId,
                        principalTable: "DataUserMK",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MKLocation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Country = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NameStadium = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Capacity = table.Column<int>(type: "int", nullable: false),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TicketForMaksKorzId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MKLocation", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MKLocation_MKTicket_TicketForMaksKorzId",
                        column: x => x.TicketForMaksKorzId,
                        principalTable: "MKTicket",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "MKConcert",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    DataUserForKorzId = table.Column<int>(type: "int", nullable: false),
                    DataConcert = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EndTime = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MKConcert", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MKConcert_DataUserMK_DataUserForKorzId",
                        column: x => x.DataUserForKorzId,
                        principalTable: "DataUserMK",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MKConcert_MKLocation_LocationId",
                        column: x => x.LocationId,
                        principalTable: "MKLocation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MKConcert_DataUserForKorzId",
                table: "MKConcert",
                column: "DataUserForKorzId");

            migrationBuilder.CreateIndex(
                name: "IX_MKConcert_LocationId",
                table: "MKConcert",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_MKDataUserCardFor_DataUserForKorzId",
                table: "MKDataUserCardFor",
                column: "DataUserForKorzId");

            migrationBuilder.CreateIndex(
                name: "IX_MKLocation_TicketForMaksKorzId",
                table: "MKLocation",
                column: "TicketForMaksKorzId");

            migrationBuilder.CreateIndex(
                name: "IX_MKTicket_DataUserForMaksKorzId",
                table: "MKTicket",
                column: "DataUserForMaksKorzId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MKConcert");

            migrationBuilder.DropTable(
                name: "MKDataUserCardFor");

            migrationBuilder.DropTable(
                name: "MKLocation");

            migrationBuilder.DropTable(
                name: "MKTicket");

            migrationBuilder.DropTable(
                name: "DataUserMK");
        }
    }
}
