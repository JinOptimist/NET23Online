using System.Globalization;
using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class RockBandsRepository : BaseRepository<RockBandsData>, IRockBandsRepository
    {
        public RockBandsRepository(WebContext webContext) : base(webContext) { }

        public override void Add(RockBandsData model)
        {
            var normalizedName = model.Name?.Trim().ToLower();
            if (_dbSet.Any(x => x.Name.ToLower() == normalizedName))
            {
                throw new InvalidOperationException($"Rock band with name '{normalizedName}' already exists.");
            }

            model.Name = CultureInfo.CurrentCulture.TextInfo.ToTitleCase(normalizedName);
            base.Add(model);
        }

        public List<RockBandsData> GetAllWithGenres()
        {
            return _dbSet
                .Include(b => b.RockBandGenres)
                .ThenInclude(bg => bg.Genre)
                .OrderBy(b => b.Id)
                .ToList();
        }

        public List<RockBandsData> GetByGenreIdsWithGenres(int[] genreIds)
        {
            if (genreIds == null || genreIds.Length == 0)
            {
                return GetAllWithGenres();
            }
            return _dbSet
                .Include(b => b.RockBandGenres)
                .ThenInclude(bg => bg.Genre)
                .Where(b => b.RockBandGenres.Any(bg => genreIds.Contains(bg.GenreId)))
                .OrderBy(b => b.Id)
                .ToList();
        }
    }

}
