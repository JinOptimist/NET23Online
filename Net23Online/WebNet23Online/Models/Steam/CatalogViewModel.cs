namespace WebNet23Online.Models.Steam
{
    public class CatalogViewModel
    {
        public string? Genre { get; set; }
        public decimal? MaxPrice { get; set; }
        public IList<SteamGameViewModel> Games { get; set; } = Array.Empty<SteamGameViewModel>();
    }
}