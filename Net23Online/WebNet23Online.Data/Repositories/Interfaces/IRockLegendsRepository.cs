using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface IRockLegendsRepository : IBaseRepository<RockLegendsData>
    {
        void Update(RockLegendsData model);
    }
}