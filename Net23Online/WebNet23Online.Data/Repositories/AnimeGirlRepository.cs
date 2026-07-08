using Microsoft.EntityFrameworkCore;
using System.Data;
using System.Linq.Expressions;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class AnimeGirlRepository : BaseRepository<AnimeGirlData>, IAnimeGirlRepository
    {
        public AnimeGirlRepository(WebContext webContext) : base(webContext) { }

        public List<AnimeGirlData> GetAllIncludeAnime()
        {
            return _dbSet
                .Include(g => g.Animes)
                .ToList();
        }

        public List<AnimeGirlData> GetAllIncludeAnime(string? sortBy)
        {
            var dataSource = _dbSet
                .Include(g => g.Animes)
                .AsQueryable();

            if (sortBy == "Id")
            {
                dataSource = dataSource.OrderBy(x => x.Id);
            }
            else if (sortBy == "Title")
            {
                dataSource = dataSource.OrderBy(x => x.Name);
            }
            else if (sortBy == "ConnectedAnimeTitles")
            {
                dataSource = dataSource.OrderBy(x => x.Animes.Count);
            }
            else if (sortBy == "Url")
            {
                dataSource = dataSource.OrderBy(x => x.Url);
            }

            return dataSource.ToList();
        }

        public override void Add(AnimeGirlData model)
        {
            if (model.Name == model.Description)
            {
                throw new Exception("Be more creative");
            }

            if (model.Name.StartsWith("TestRace", StringComparison.OrdinalIgnoreCase))
            {
                Thread.Sleep(2500);
            }

            base.Add(model);
        }

        public bool IsNameFree(string name)
        {
            return !_dbSet.Any(x => x.Name == name);
        }

        public List<AnimeGirlData> GetByIds(IEnumerable<int> ids)
        {
            var idList = ids.Distinct().ToList();
            if (idList.Count == 0)
            {
                return new List<AnimeGirlData>();
            }

            return _dbSet
                .Where(x => idList.Contains(x.Id))
                .ToList();
        }

        public List<AnimeGirlData> IncrementLikes(IEnumerable<int> ids)
        {
            var idList = ids.Distinct().ToList();
            if (idList.Count == 0)
            {
                return new List<AnimeGirlData>();
            }

            var characters = _dbSet
                .Where(x => idList.Contains(x.Id))
                .ToList();

            foreach (var character in characters)
            {
                character.Likes++;
            }

            _context.SaveChanges();
            return characters;
        }

        public void Link(int animeId, int heroId)
        {
            var hero = _context.AnimeGirls
                .Include(h => h.Animes)
                .First(x => x.Id == heroId);

            if (hero.Animes.Any(a => a.Id == animeId))
            {
                return;
            }

            var anime = _context.Animes.First(x => x.Id == animeId);
            anime.Heroes.Add(hero);
            _context.SaveChanges();
        }
    }
}
