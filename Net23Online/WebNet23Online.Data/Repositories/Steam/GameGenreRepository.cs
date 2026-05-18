
using WebNet23Online.Data.Models.Steam;
using WebNet23Online.Data.Repositories.Interfaces.Steam;

namespace WebNet23Online.Data.Repositories.Steam
{
    public class GameGenreRepository : BaseRepository<GameGenreData>, IGameGenreRepository
    {
        public GameGenreRepository(WebContext context) : base(context)
        {
        }

        public List<GameGenreData> GetByIds(List<int> ids)
        {
            var gameGenres = _dbSet
                .Where(g => ids.Contains(g.Id))
                .ToList();
            return gameGenres;
        }
    }
}
