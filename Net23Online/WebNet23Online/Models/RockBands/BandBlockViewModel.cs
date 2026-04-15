namespace WebNet23Online.Models.RockBands
{
    public class BandBlockViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string? ImageUrl { get; set; }
        public List<string> Genres { get; set; } = new();
    }
}
