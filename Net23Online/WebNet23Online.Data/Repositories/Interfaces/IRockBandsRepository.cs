using System.Linq;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface IRockBandsRepository
    {
        IQueryable<RockBandsData> AsNoTracking();
        void Add(RockBandsData model);
    }
}