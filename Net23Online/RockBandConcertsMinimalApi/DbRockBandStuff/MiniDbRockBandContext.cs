using Microsoft.EntityFrameworkCore;

namespace RockBandConcertsMinimalApi.DbRockBandStuff
{
    public class MiniDbRockBandContext : DbContext
    {
        public DbSet<RockBandConcert> RockBandConcerts { get; set; }
        public MiniDbRockBandContext(DbContextOptions<MiniDbRockBandContext> options) : base(options) { }
    }
}
