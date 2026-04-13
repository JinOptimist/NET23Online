using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data
{
    public class WebContext : DbContext
    {
        public DbSet<AnimeGirlData> AnimeGirls { get; set; }
        public DbSet<MazeData> Mazes { get; set; }
        public DbSet<RockBandsData> RockBand {  get; set; }    

        public WebContext(DbContextOptions<WebContext> options) : base(options) { }
    }
}
