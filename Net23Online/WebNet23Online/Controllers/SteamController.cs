using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.Steam;
using WebNet23Online.Services;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class SteamController : Controller
    {
        private readonly ICatalogService _catalogService;

        public SteamController(ICatalogService catalogService)
        {
            _catalogService = catalogService;
        }

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
            var model = _catalogService.GetCatalog();

            return View(model);
        }

        [HttpPost]
        public IActionResult Catalog(CatalogFilterViewModel filter)
        {
            var model = _catalogService.GetCatalog(filter);

            return View(model);
        }
    }
}
