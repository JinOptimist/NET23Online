using System.Linq;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface IRockBandsRepository : IBaseRepository<RockBandsData>
    {
        List<RockBandsData> GetAllWithGenres();
        List<RockBandsData> GetByGenreIdsWithGenres(int[] genreIds);
        void UpdateBandGenres(int bandId, int[] genreIds);
        bool IsBandNameTaken(string name);
    }
}