using WebNet23Online.Data;
using WebNet23Online.Data.Models.Steam;
using WebNet23Online.Data.Models.Steam.Enums;
using WebNet23Online.Models.Steam;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class CatalogService : ICatalogService
    {
        public const int SPECIAL_OFFERS_PREVIEW_COUNT = 6;
        private readonly WebContext _context;

        public CatalogService(WebContext context)
        {
            _context = context;
        }

        public SteamHomeViewModel GetGamesForHomePage()
        {
            var viewModel = new SteamHomeViewModel
            {
                Featured = _context.Games
                   .Skip(SPECIAL_OFFERS_PREVIEW_COUNT)
                   .Select(g => new SteamGameViewModel
                   {
                       Title = g.Title,
                       Description = g.Description,
                       ImageUrl = g.ImageUrl,
                       Price = g.Price,
                       Genre = g.Genre.ToString(),
                   })
                   .ToList(),

                SpecialOffers = _context.Games
                   .Take(SPECIAL_OFFERS_PREVIEW_COUNT)
                   .Select(g => new SteamGameViewModel
                   {
                       Title = g.Title,
                       Description = g.Description,
                       ImageUrl = g.ImageUrl,
                       Price = g.Price,
                       Genre = g.Genre.ToString(),
                   })
                   .ToList()
            };

            return viewModel;
        }

        public CatalogViewModel GetCatalog(CatalogFilterViewModel filter = null)
        {
            filter ??= new CatalogFilterViewModel();

            var genres = Enum.GetValues(typeof(GameGenre))
                             .Cast<GameGenre>()
                             .ToList();

            var games = _context.Games.AsQueryable();

            if (!string.IsNullOrEmpty(filter.Genre) && filter.Genre != "All")
            {
                games = games.Where(g => g.Genre.ToString() == filter.Genre);
            }

            if (filter.MaxPrice.HasValue)
            {
                games = games.Where(g => g.Price <= filter.MaxPrice);
            }

            return new CatalogViewModel
            {
                Filter = filter,
                Games = games
                    .Select(g => new SteamGameViewModel
                    {
                        Title = g.Title,
                        Description = g.Description,
                        ImageUrl = g.ImageUrl,
                        Price = g.Price,
                        Genre = g.Genre.ToString(),
                    })
                    .ToList(),
                Genres = genres
            };
        }

        public void AddGame(AddGameViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException(nameof(viewModel), "Game data cannot be null");
            }

            var gameEntity = new GameData
            {
                Title = viewModel.Title,
                Description = viewModel.Description,
                ImageUrl = viewModel.ImageUrl,
                Price = viewModel.Price,
                Genre = viewModel.Genre
            };

            _context.Games.Add(gameEntity);
            _context.SaveChanges();
        }
    }
}
