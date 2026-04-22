using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data.Enums.Steam;
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
                Genres = Enum.GetValues(typeof(GameGenre))
                                .Cast<GameGenre>()
                                .Where(g => g != GameGenre.All)
                                .ToList(),
                Publishers = _catalogService.GetListItemsWithPublishers()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddGame(AddGameViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = Enum.GetValues(typeof(GameGenre))
                                .Cast<GameGenre>()
                                .Where(g => g != GameGenre.All)
                                .ToList();
                viewModel.Publishers = _catalogService.GetListItemsWithPublishers();
                return View(viewModel);
            }
            _catalogService.AddGame(viewModel);

            return RedirectToAction(nameof(Catalog));
        }

        [HttpGet]
        public IActionResult GameDetails(int id)
        {
            var gameData = _catalogService.GetGameDetails(id);

            if (gameData == null)
            {
                return NotFound();
            }

            var viewModel = new GameDetailsViewModel
            {
                Id = gameData.Id,
                Title = gameData.Title,
                Description = gameData.Description,
                ImageUrl = gameData.ImageUrl,
                Price = gameData.Price,
                Genre = gameData.Genre,
                PublisherName = gameData.Publisher?.Name ?? "Unknown",
                PublisherId = gameData.PublisherId
            };

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult EditGame(int id)
        {
            var game = _catalogService.GetGameDetails(id);

            if (game == null)
            {
                return NotFound();
            }

            var viewModel = new EditGameViewModel
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ImageUrl = game.ImageUrl,
                Price = game.Price,
                Genre = game.Genre,
                PublisherId = game.PublisherId,
                Genres = Enum.GetValues(typeof(GameGenre))
                                .Cast<GameGenre>()
                                .Where(g => g != GameGenre.All)
                                .ToList(),
                Publishers = _catalogService.GetListItemsWithPublishers()
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditGame(EditGameViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Genres = Enum.GetValues(typeof(GameGenre))
                       .Cast<GameGenre>()
                       .Where(g => g != GameGenre.All)
                       .ToList();
                viewModel.Publishers = _catalogService.GetListItemsWithPublishers();

                return View(viewModel);
            }

            _catalogService.UpdateGame(viewModel);

            return RedirectToAction(nameof(GameDetails), new { id = viewModel.Id });
        }
    }
}
