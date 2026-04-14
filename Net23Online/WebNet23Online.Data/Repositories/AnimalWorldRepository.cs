using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class AnimalWorldRepository : BaseRepository<BeastData>, IAnimalWorldRepository
    {
        public AnimalWorldRepository(WebContext webContext) : base(webContext)
        {
        }

        public List<BeastData> GetRandomBeasts()
        {
            return _dbSet.OrderBy(r => EF.Functions.Random()).Take(2).ToList();
        }

        public bool IsExists(string beastName)
        {
            return _dbSet.Any(animal => animal.BeastName.ToLower() == beastName.ToLower());
        }

        public BeastData GetBeastByName(string beastName)
        {
            return _dbSet.FirstOrDefault(animal => animal.BeastName.ToLower() == beastName.ToLower());
        }
    }
}
