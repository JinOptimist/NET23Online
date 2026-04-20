using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
            var publishers = _catalogService.GetPublishers();
            var publisherListItems = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "SelectPublisher",
                    Value = ""
                }
            };

            publisherListItems.AddRange(publishers.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }));

            var viewModel = new AddGameViewModel
            {
                AllGenres = Enum.GetValues(typeof(GameGenre))
                                .Cast<GameGenre>()
                                .Where(g => g != GameGenre.All)
                                .ToList(),
                Publishers = publisherListItems
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult AddGame(AddGameViewModel viewModel)
        {
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

            var publishers = _catalogService.GetPublishers();

            var publisherListItems = new List<SelectListItem>
            {
                new SelectListItem
                {
                    Text = "Select Publisher",
                    Value = ""
                }
            };

            publisherListItems.AddRange(publishers.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString(),
                Selected = x.Id == game.PublisherId
            }));

            var viewModel = new EditGameViewModel
            {
                Id = game.Id,
                Title = game.Title,
                Description = game.Description,
                ImageUrl = game.ImageUrl,
                Price = game.Price,
                Genre = game.Genre,
                PublisherId = game.PublisherId,
                AllGenres = Enum.GetValues(typeof(GameGenre))
                                .Cast<GameGenre>()
                                .Where(g => g != GameGenre.All)
                                .ToList(),
                Publishers = publisherListItems
            };

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult EditGame(EditGameViewModel viewModel)
        {
            _catalogService.UpdateGame(viewModel);

            return RedirectToAction(nameof(GameDetails), new { id = viewModel.Id });
        }
    }
}
