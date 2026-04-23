namespace WebNet23Online.Data.Models
{
    public class RockLegendsGenres : BaseModel
    {
        public string Name { get; set; }
        public string? CoverUrl { get; set; }
        public virtual List<RockLegendsData> Groups { get; set; } = new();

    }
}
