using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Models.AnimalWorld;
using WebNet23Online.Data.Models.MaksKorz;
using WebNet23Online.Data.Models.Steam;

namespace WebNet23Online.Data
{
    public class WebContext : DbContext
    {
        public DbSet<AnimeGirlData> AnimeGirls { get; set; }
        public DbSet<AnimeData> Animes { get; set; }
        public DbSet<AnimeStudioData> AnimeStudios { get; set; }
        public DbSet<UserData> Users { get; set; }
        public DbSet<MazeData> Mazes { get; set; }
        public DbSet<HabitData> Habits { get; set; }
        public DbSet<HabitDoneDatesData> HabitDoneDates { get; set; }
        public DbSet<HabitTrackerDiaryData> DiaryEntries { get; set; }
        public DbSet<AnimalFamilyData> AnimalFamilies { get; set; }
        public DbSet<AnimalSpeciesData> AnimalSpecies { get; set; }
        public DbSet<ZooData> Zoos { get; set; }
        public DbSet<LittleLemonData> LittleLemon { get; set; }
        public DbSet<LittleLemonGuestData> LittleLemonGuests { get; set; }
        public DbSet<RockBandsData> RockBand { get; set; }
        public DbSet<FoodItemData> FoodItems { get; set; }
        public DbSet<IngredientData> Ingredients { get; set; }
        public DbSet<MenuData> Menus { get; set; }
        public DbSet<GenreOfRockBandsData> RockBandGenresDictionary { get; set; }
        public DbSet<RockBandGenreData> RockBandGenres { get; set; }

        public DbSet<RockLegendsData> RockLegends { get; set; }
        public DbSet<RockLegendsGenres> RockLegendsGenres { get; set; }

        public DbSet<SlayTheSpire2HeroesData> SlayTheSpire2Heroes { get; set; }

        public DbSet<GameData> Games { get; set; }
        public DbSet<PublisherData> Publishers { get; set; }
