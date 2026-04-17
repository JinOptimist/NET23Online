using WebNet23Online.Data.Models.AnimalWorld;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface IAnimalWorldRepository : IBaseRepository<AnimalSpeciesData>
    {
        bool IsExists(string beastName);

        List<AnimalSpeciesData> GetRandomBeasts();

        AnimalSpeciesData GetBeastByName(string beastName);
    }
}
