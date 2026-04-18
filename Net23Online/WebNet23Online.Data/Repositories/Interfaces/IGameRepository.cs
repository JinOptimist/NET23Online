
using WebNet23Online.Data.HelperModels;
using WebNet23Online.Data.Models.Steam;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface IGameRepository : IBaseRepository<GameData>
    {
        List<GameData> GetFiltered(GameFilter filter);
        List<GameData> GetFeaturedForHomePage();
        List<GameData> GetSpecialOffersForHomePage();
    }
}
