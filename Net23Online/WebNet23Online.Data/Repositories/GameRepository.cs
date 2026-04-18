
using WebNet23Online.Data.HelperModels;
using WebNet23Online.Data.Models.Steam;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
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

            if (filter.Genre.HasValue)
            {
                games = games.Where(g => g.Genre == filter.Genre.Value);
            }

            if (filter.MaxPrice.HasValue)
            {
                games = games.Where(g => g.Price <= filter.MaxPrice.Value);
            }

            return games.ToList();
        }

        public List<GameData> GetFeaturedForHomePage()
        {          
            var featured = _dbSet.Skip(SPECIAL_OFFERS_PREVIEW_COUNT).ToList();

            return featured;
        }

        public List<GameData> GetSpecialOffersForHomePage()
        {
            var specialOffers = _dbSet.Take(SPECIAL_OFFERS_PREVIEW_COUNT).ToList();
            
            return specialOffers;
        }
    }
}
