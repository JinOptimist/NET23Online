
using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.HelperModels;
using WebNet23Online.Data.Models.Steam;
using WebNet23Online.Data.Repositories.Interfaces.Steam;

namespace WebNet23Online.Data.Repositories.Steam
{
    public class GameRepository : BaseRepository<GameData>, IGameRepository
    {
        public const int SPECIAL_OFFERS_PREVIEW_COUNT = 6;

        public GameRepository(WebContext context) : base(context)
        {
        }

        public List<GameData> GetFiltered(GameFilter filter)
        {
            var games = _dbSet.AsQueryable(); 

            //if (filter.Genre.HasValue)
            //{
            //    games = games.Where(g => g.Genre == filter.Genre.Value);
            //}

            if (filter.MaxPrice.HasValue)
            {
                games = games.Where(g => g.Price <= filter.MaxPrice.Value);
            }

            return games.ToList();
        }

        public List<GameData> GetFeaturedForHomePage()
        {          
            var featured = _dbSet
                .Include(g => g.GameGenres)
                .Skip(SPECIAL_OFFERS_PREVIEW_COUNT).ToList();

            return featured;
        }

        public List<GameData> GetSpecialOffersForHomePage()
        {
            var specialOffers = _dbSet
                .Include(g => g.GameGenres)
                .Take(SPECIAL_OFFERS_PREVIEW_COUNT).ToList();
            
            return specialOffers;
        }

        public GameData GetGameWithPublisherAndGenres(int id)
        {
            var gameData = _dbSet
                .Include(g => g.Publisher)
                .Include(g => g.GameGenres)
                .FirstOrDefault(g => g.Id == id);
            return gameData;
        }
    }
}
