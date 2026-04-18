
using WebNet23Online.Data.Enums.Steam;
using WebNet23Online.Data.HelperModels;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Models.Steam;
using WebNet23Online.Data.Repositories.Interfaces;

using WebNet23Online.Models.Steam;

using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class CatalogService : ICatalogService
    {       
        private readonly IGameRepository _gameRepository;

        public CatalogService(IGameRepository gameRepository)
        {
            _gameRepository = gameRepository;
        }

        public SteamHomeViewModel GetGamesForHomePage()
        {     
            var viewModel = new SteamHomeViewModel
            {
                Featured = _gameRepository.GetFeaturedForHomePage()
                   .Select(g => new SteamGameViewModel
                   {
                       Title = g.Title,
                       Description = g.Description,
                       ImageUrl = g.ImageUrl,
                       Price = g.Price,
                       Genre = g.Genre.ToString(),
                   })
                   .ToList(),

                SpecialOffers = _gameRepository.GetSpecialOffersForHomePage()
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

            var repoFilter = new GameFilter
            {
                Genre = ParseGenre(filter.Genre),
                MaxPrice = filter.MaxPrice
            };

            var games = _gameRepository.GetFiltered(repoFilter);

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

            _gameRepository.Add(gameEntity);     
        }

        private GameGenre? ParseGenre(string genreString)
        {
            if (string.IsNullOrEmpty(genreString) || genreString == "All")
            {
                return null;
            }

            return Enum.TryParse<GameGenre>(genreString, out var genre) ? genre : null;
        }
    }
}
