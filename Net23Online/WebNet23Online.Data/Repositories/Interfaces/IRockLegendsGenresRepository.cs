using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface IRockLegendsGenresRepository : IBaseRepository<RockLegendsGenres>
    {
        bool IsNameFree(string name);
        List<RockLegendsGenres> GetAllWithGroups();
    }
}