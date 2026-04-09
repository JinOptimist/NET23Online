using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data
{
    public class WebContext : DbContext
    {
        public DbSet<AnimeGirlData> AnimeGirls { get; set; }
        public DbSet<MazeData> Mazes { get; set; }
        
        //DelightBistro
        public DbSet<FoodItemData> FoodItems {  get; set; }

        public WebContext(DbContextOptions<WebContext> options) : base(options) { }
    }
}
