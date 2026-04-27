using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebNet23Online.Models.Steam
{
    public class CatalogViewModel
    {
        public CatalogFilterViewModel Filter { get; set; }
        public List<SteamGameViewModel> Games { get; set; } = new();
        public List<SelectListItem> GameGenres { get; set; } = new();
    }
}