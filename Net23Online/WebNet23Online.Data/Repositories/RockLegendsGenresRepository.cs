using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class RockLegendsGenresRepository : BaseRepository<RockLegendsGenres>, IRockLegendsGenresRepository
    {
        public RockLegendsGenresRepository(WebContext webContext) : base(webContext) { }

        public List<RockLegendsGenres> GetAllWithGroups()
        {
            return _dbSet.Include(x => x.Groups).ToList();
        }
    }
}