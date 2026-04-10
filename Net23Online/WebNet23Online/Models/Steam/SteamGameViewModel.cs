namespace WebNet23Online.Models.Steam
{
    public class SteamGameViewModel
    {
        public string Title { get; set; } = string.Empty;
        public string ImageUrl { get; set; } = string.Empty;
        public decimal Price { get; set; }
        public string Genre { get; set; } = string.Empty;
        public string? Description { get; set; }
    }
}
