
using WebNet23Online.Data.Enums.Steam;
using WebNet23Online.Data.HelperModels;
using WebNet23Online.Data.Models.Steam;
using WebNet23Online.Data.Repositories.Interfaces;

using WebNet23Online.Models.Steam;

using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class CatalogService : ICatalogService
    {
        private readonly IGameRepository _gameRepository;
        private readonly IPublisherRepository _publisherRepository;

        public CatalogService(IGameRepository gameRepository, IPublisherRepository publisherRepository)
        {
            _gameRepository = gameRepository;
            _publisherRepository = publisherRepository;
        }

        public SteamHomeViewModel GetGamesForHomePage()
        {
            var viewModel = new SteamHomeViewModel
            {
                Featured = _gameRepository.GetFeaturedForHomePage()
                   .Select(g => new SteamGameViewModel
                   {
                       Id = g.Id,
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
                       Id = g.Id,
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
                        Id = g.Id,
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
                Genre = viewModel.Genre,
                PublisherId = viewModel.PublisherId //?
            };

            //по сути,  то же самое PublisherId = viewModel.PublisherId???
            //if (viewModel.PublisherId is not null 
            //    && viewModel.PublisherId > 0)
            //{
            //    var publisher = _publisherRepository.Get(viewModel.PublisherId.Value);
            //    gameEntity.Publisher = publisher;
            //}

            _gameRepository.Add(gameEntity);
        }

        public List<PublisherData> GetPublishers()
        {
            var publishers = _publisherRepository.GetAll();
            return publishers;
        }

        public GameData GetGameDetails(int id)
        {
            var game = _gameRepository.GetGameWithPublisher(id);
            return game;
        }

        public void UpdateGame(EditGameViewModel viewModel)
        {
            var game = _gameRepository.Get(viewModel.Id);

            if (game == null)
            {
                throw new ArgumentException($"Game not found");
            }

            game.Title = viewModel.Title;
            game.Description = viewModel.Description;
            game.ImageUrl = viewModel.ImageUrl;
            game.Price = viewModel.Price;
            game.Genre = viewModel.Genre;
            game.PublisherId = viewModel.PublisherId;

            _gameRepository.Update(game);
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
