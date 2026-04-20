using Microsoft.EntityFrameworkCore;
using System.Data;
using WebNet23Online.Data.Models;
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
        public DbSet<HabitTrackerData> HabitTracker { get; set; }
        //public DbSet<HabitData> Habit { get; set; }
        public DbSet<BeastData> Beasts { get; set; }
        public DbSet<RockBandsData> RockBand { get; set; }
        public DbSet<FoodItemData> FoodItems { get; set; }
        public DbSet<DataUserData> DataUser { get; set; }//*

        public DbSet<RockLegendsData> RockLegends { get; set; }
        public DbSet<GameData> Games { get; set; }

        public WebContext(DbContextOptions<WebContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AnimeData>()
                .HasMany(x => x.Heroes)
                .WithMany(x => x.Animes);

            modelBuilder.Entity<AnimeStudioData>()
                .HasMany(x => x.Animes)
                .WithOne(x => x.Studio)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<UserData>()
                .HasOne(x => x.UserProfile)
                .WithOne(x => x.User)
                .HasForeignKey<UserData>(x => x.UserProfileId);

            modelBuilder.Entity<UserData>()
                .HasMany(x => x.MyFriends)
                .WithMany(x => x.WhoIsMyFriends);

            base.OnModelCreating(modelBuilder);
        }
    }
}
