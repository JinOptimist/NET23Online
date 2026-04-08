namespace WebNet23Online.Models.Steam
{
    public class CatalogViewModel
    {
        public CatalogFilterViewModel Filter { get; set; }
        public IList<SteamGameViewModel> Games { get; set; } = Array.Empty<SteamGameViewModel>();
        public IList<GameGenre> Genres { get; set; }
    }
}