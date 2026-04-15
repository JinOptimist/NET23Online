using Microsoft.AspNetCore.Mvc;

using WebNet23Online.Data.Models.Steam.Enums;
using WebNet23Online.Models.Steam;
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
            var viewModel = _catalogService.GetGamesForHomePage();

            return View(viewModel);
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

        [HttpGet]
        public IActionResult AddGame()
        {
            var viewModel = new AddGameViewModel
            {
                AllGenres = Enum.GetValues(typeof(GameGenre))
                                .Cast<GameGenre>()
                                .Where(g => g != GameGenre.All)
                                .ToList()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddGame(AddGameViewModel viewModel)
        {
            viewModel.AllGenres = Enum.GetValues(typeof(GameGenre))
                                .Cast<GameGenre>()
                                .Where(g => g != GameGenre.All)
                                .ToList();
            _catalogService.AddGame(viewModel);

            return RedirectToAction(nameof(Catalog));
        }
    }
}
