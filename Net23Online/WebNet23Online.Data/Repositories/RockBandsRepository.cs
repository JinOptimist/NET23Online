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

        public void UpdateBandGenres(int bandId, int[] genreIds)
        {
            var normalizedGenreIds = (genreIds ?? Array.Empty<int>())
                .Where(x => x > 0)
                .Distinct()
                .ToHashSet();

            var band = _dbSet
                .Include(b => b.RockBandGenres)
                .FirstOrDefault(b => b.Id == bandId);

            if (band == null)
            {
                return;
            }

            var toRemove = band.RockBandGenres
                .Where(bg => !normalizedGenreIds.Contains(bg.GenreId))
                .ToList();

            foreach (var bg in toRemove)
            {
                band.RockBandGenres.Remove(bg);
            }

            var existing = band.RockBandGenres.Select(bg => bg.GenreId).ToHashSet();
            var toAdd = normalizedGenreIds.Where(id => !existing.Contains(id));

            foreach (var id in toAdd)
            {
                band.RockBandGenres.Add(new RockBandGenreData { RockBandId = band.Id, GenreId = id });
            }

            _context.SaveChanges();
        }
    }

}
