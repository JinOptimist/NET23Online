using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.Steam;

namespace WebNet23Online.Controllers
{
    public class SteamController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            var model = new SteamHomeViewModel()
            {
                SpecialOffers = SteamCatalog.All.Take(SteamCatalog.SPECIAL_OFFERS_PREVIEW_COUNT).ToList(),
                Featured = SteamCatalog.All.Skip(SteamCatalog.SPECIAL_OFFERS_PREVIEW_COUNT).ToList()
            };

            return View(model);
        }

        [HttpGet]
        public IActionResult Catalog()
        {
            var model = new CatalogViewModel
            { 
                Games = SteamCatalog.All.ToList(),
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult Catalog(string? genre, decimal? maxPrice)
        {
            var games = SteamCatalog.All.AsQueryable();
            if (!string.IsNullOrEmpty(genre) && genre != "All")
            {
                games = games.Where(g => g.Genre == genre);
            }

            if (maxPrice.HasValue)
            {
                games = games.Where(g => g.Price <= maxPrice);
            }

            var model = new CatalogViewModel
            {
                Genre = genre,
                MaxPrice = maxPrice,
                Games = games.ToList(),
            };

            return View(model);
        }
    }
}
