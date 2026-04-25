using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WebNet23Online.Data.Migrations
{
    /// <inheritdoc />
    public partial class RefactorDatabase : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AnimeGirls",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeGirls", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AnimeStudios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeStudios", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "HabitTracker",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitTracker", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Ingredients",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Ingredients", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LittleLemonGuests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LittleLemonGuests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Mazes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MazeType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mazes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Menus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Menus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publishers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publishers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RockBand",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Url = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RockBand", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RockBandGenresDictionary",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RockBandGenresDictionary", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RockLegendsGenres",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RockLegendsGenres", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SlayTheSpire2Heroes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SlayTheSpire2Heroes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "UserProfileData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FavBook = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PetName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserProfileData", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Animes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CoverUrl = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StudioId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Animes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Animes_AnimeStudios_StudioId",
                        column: x => x.StudioId,
                        principalTable: "AnimeStudios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "HabitData",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ColorOfDot = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WeekResults = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DoneCount = table.Column<int>(type: "int", nullable: false),
                    Percent = table.Column<double>(type: "float", nullable: false),
                    HabitTrackerDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HabitData", x => x.Id);
                    table.ForeignKey(
                        name: "FK_HabitData_HabitTracker_HabitTrackerDataId",
                        column: x => x.HabitTrackerDataId,
                        principalTable: "HabitTracker",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "LittleLemon",
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
                    GuestId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LittleLemon", x => x.Id);
                    table.ForeignKey(
                        name: "FK_LittleLemon_LittleLemonGuests_GuestId",
                        column: x => x.GuestId,
                        principalTable: "LittleLemonGuests",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "FoodItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Price = table.Column<int>(type: "int", nullable: false),
                    ImgURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    MenuDataId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_FoodItems_Menus_MenuDataId",
                        column: x => x.MenuDataId,
                        principalTable: "Menus",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Games",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImageUrl = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PublisherId = table.Column<int>(type: "int", nullable: true),
                    Price = table.Column<decimal>(type: "decimal(18,2)", precision: 18, scale: 2, nullable: false),
                    Genre = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Games", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Games_Publishers_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publishers",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "RockBandGenres",
                columns: table => new
                {
                    RockBandId = table.Column<int>(type: "int", nullable: false),
                    GenreId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RockBandGenres", x => new { x.RockBandId, x.GenreId });
                    table.ForeignKey(
                        name: "FK_RockBandGenres_RockBandGenresDictionary_GenreId",
                        column: x => x.GenreId,
                        principalTable: "RockBandGenresDictionary",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RockBandGenres_RockBand_RockBandId",
                        column: x => x.RockBandId,
                        principalTable: "RockBand",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RockLegends",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroupNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Likes = table.Column<int>(type: "int", nullable: false),
                    RockLegendsGenresId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RockLegends", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RockLegends_RockLegendsGenres_RockLegendsGenresId",
                        column: x => x.RockLegendsGenresId,
                        principalTable: "RockLegendsGenres",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Role = table.Column<int>(type: "int", nullable: false),
                    UserProfileId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_UserProfileData_UserProfileId",
                        column: x => x.UserProfileId,
                        principalTable: "UserProfileData",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnimeDataAnimeGirlData",
                columns: table => new
                {
                    AnimesId = table.Column<int>(type: "int", nullable: false),
                    HeroesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimeDataAnimeGirlData", x => new { x.AnimesId, x.HeroesId });
                    table.ForeignKey(
                        name: "FK_AnimeDataAnimeGirlData_AnimeGirls_HeroesId",
                        column: x => x.HeroesId,
                        principalTable: "AnimeGirls",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimeDataAnimeGirlData_Animes_AnimesId",
                        column: x => x.AnimesId,
                        principalTable: "Animes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "FoodItemDataIngredientData",
                columns: table => new
                {
                    FoodItemsId = table.Column<int>(type: "int", nullable: false),
                    IngredientsListId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FoodItemDataIngredientData", x => new { x.FoodItemsId, x.IngredientsListId });
                    table.ForeignKey(
                        name: "FK_FoodItemDataIngredientData_FoodItems_FoodItemsId",
                        column: x => x.FoodItemsId,
                        principalTable: "FoodItems",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FoodItemDataIngredientData_Ingredients_IngredientsListId",
                        column: x => x.IngredientsListId,
                        principalTable: "Ingredients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AnimalFamilies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalFamilyName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalFamilies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalFamilies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "UserDataUserData",
                columns: table => new
                {
                    MyFriendsId = table.Column<int>(type: "int", nullable: false),
                    WhoIsMyFriendsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserDataUserData", x => new { x.MyFriendsId, x.WhoIsMyFriendsId });
                    table.ForeignKey(
                        name: "FK_UserDataUserData_Users_MyFriendsId",
                        column: x => x.MyFriendsId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserDataUserData_Users_WhoIsMyFriendsId",
                        column: x => x.WhoIsMyFriendsId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Zoos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ZooName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Zoos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Zoos_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnimalSpecies",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AnimalSpeciesName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NativeRange = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AnimalFamilyId = table.Column<int>(type: "int", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalSpecies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AnimalSpecies_AnimalFamilies_AnimalFamilyId",
                        column: x => x.AnimalFamilyId,
                        principalTable: "AnimalFamilies",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AnimalSpecies_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AnimalSpeciesDataZooData",
                columns: table => new
                {
                    AnimalSpeciesId = table.Column<int>(type: "int", nullable: false),
                    ZooDataId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AnimalSpeciesDataZooData", x => new { x.AnimalSpeciesId, x.ZooDataId });
                    table.ForeignKey(
                        name: "FK_AnimalSpeciesDataZooData_AnimalSpecies_AnimalSpeciesId",
                        column: x => x.AnimalSpeciesId,
                        principalTable: "AnimalSpecies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AnimalSpeciesDataZooData_Zoos_ZooDataId",
                        column: x => x.ZooDataId,
                        principalTable: "Zoos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AnimalFamilies_UserId",
                table: "AnimalFamilies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSpecies_AnimalFamilyId",
                table: "AnimalSpecies",
                column: "AnimalFamilyId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSpecies_UserId",
                table: "AnimalSpecies",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimalSpeciesDataZooData_ZooDataId",
                table: "AnimalSpeciesDataZooData",
                column: "ZooDataId");

            migrationBuilder.CreateIndex(
                name: "IX_AnimeDataAnimeGirlData_HeroesId",
                table: "AnimeDataAnimeGirlData",
                column: "HeroesId");

            migrationBuilder.CreateIndex(
                name: "IX_Animes_StudioId",
                table: "Animes",
                column: "StudioId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItemDataIngredientData_IngredientsListId",
                table: "FoodItemDataIngredientData",
                column: "IngredientsListId");

            migrationBuilder.CreateIndex(
                name: "IX_FoodItems_MenuDataId",
                table: "FoodItems",
                column: "MenuDataId");

            migrationBuilder.CreateIndex(
                name: "IX_Games_PublisherId",
                table: "Games",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_HabitData_HabitTrackerDataId",
                table: "HabitData",
                column: "HabitTrackerDataId");

            migrationBuilder.CreateIndex(
                name: "IX_LittleLemon_GuestId",
                table: "LittleLemon",
                column: "GuestId");

            migrationBuilder.CreateIndex(
                name: "IX_RockBandGenres_GenreId",
                table: "RockBandGenres",
                column: "GenreId");

            migrationBuilder.CreateIndex(
                name: "IX_RockBandGenresDictionary_Name",
                table: "RockBandGenresDictionary",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RockLegends_RockLegendsGenresId",
                table: "RockLegends",
                column: "RockLegendsGenresId");

            migrationBuilder.CreateIndex(
                name: "IX_UserDataUserData_WhoIsMyFriendsId",
                table: "UserDataUserData",
                column: "WhoIsMyFriendsId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserProfileId",
                table: "Users",
                column: "UserProfileId",
                unique: true,
                filter: "[UserProfileId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Zoos_UserId",
                table: "Zoos",
                column: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AnimalSpeciesDataZooData");

            migrationBuilder.DropTable(
                name: "AnimeDataAnimeGirlData");

            migrationBuilder.DropTable(
                name: "FoodItemDataIngredientData");

            migrationBuilder.DropTable(
                name: "Games");

            migrationBuilder.DropTable(
                name: "HabitData");

            migrationBuilder.DropTable(
                name: "LittleLemon");

            migrationBuilder.DropTable(
                name: "Mazes");

            migrationBuilder.DropTable(
                name: "RockBandGenres");

            migrationBuilder.DropTable(
                name: "RockLegends");

            migrationBuilder.DropTable(
                name: "SlayTheSpire2Heroes");

            migrationBuilder.DropTable(
                name: "UserDataUserData");

            migrationBuilder.DropTable(
                name: "AnimalSpecies");

            migrationBuilder.DropTable(
                name: "Zoos");

            migrationBuilder.DropTable(
                name: "AnimeGirls");

            migrationBuilder.DropTable(
                name: "Animes");

            migrationBuilder.DropTable(
                name: "FoodItems");

            migrationBuilder.DropTable(
                name: "Ingredients");

            migrationBuilder.DropTable(
                name: "Publishers");

            migrationBuilder.DropTable(
                name: "HabitTracker");

            migrationBuilder.DropTable(
                name: "LittleLemonGuests");

            migrationBuilder.DropTable(
                name: "RockBandGenresDictionary");

            migrationBuilder.DropTable(
                name: "RockBand");

            migrationBuilder.DropTable(
                name: "RockLegendsGenres");

            migrationBuilder.DropTable(
                name: "AnimalFamilies");

            migrationBuilder.DropTable(
                name: "AnimeStudios");

            migrationBuilder.DropTable(
                name: "Menus");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "UserProfileData");
        }
    }
}
