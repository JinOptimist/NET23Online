using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface IAnimalWorldRepository : IBaseRepository<BeastData>
    {
        bool IsExists(string beastName);

        List<BeastData> GetRandomBeasts();

        BeastData GetBeastByName(string beastName);
    }
}
