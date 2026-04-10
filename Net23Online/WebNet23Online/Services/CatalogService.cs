using WebNet23Online.Models.Steam;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class CatalogService : ICatalogService
    {
        public CatalogViewModel GetCatalog(CatalogFilterViewModel filter = null)
        {
            filter ??= new CatalogFilterViewModel();

            var games = SteamCatalog.All.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Genre) && filter.Genre != "All")
            {
                games = games.Where(g => g.Genre == filter.Genre);
            }

            if (filter.MaxPrice.HasValue)
            {
                games = games.Where(g => g.Price <= filter.MaxPrice);
            }

            return new CatalogViewModel
            {
                Filter = filter,
                Games = games.ToList(),
                Genres = SteamCatalog.Genres.ToList()
            };
        }
    }
}
