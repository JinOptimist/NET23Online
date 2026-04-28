using WebNet23Online.Data.Models.Steam;

namespace WebNet23Online.Data.Repositories.Interfaces.Steam
{
    public interface IGameGenreRepository : IBaseRepository<GameGenreData>
    {
        List<GameGenreData> GetByIds(List<int> ids);
    }
}
