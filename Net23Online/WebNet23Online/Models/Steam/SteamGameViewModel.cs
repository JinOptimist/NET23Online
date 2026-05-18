namespace WebNet23Online.Models.Steam
{
    public class SteamGameViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public List<string> Genres { get; set; } = new();
        public string? Description { get; set; }
    }
}
