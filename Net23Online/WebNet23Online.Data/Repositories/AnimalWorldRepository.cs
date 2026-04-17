using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models.AnimalWorld;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class AnimalWorldRepository : BaseRepository<AnimalSpeciesData>, IAnimalWorldRepository
    {
        public const int START_PAGE_COUNT_ANIMALS = 2;

        public AnimalWorldRepository(WebContext webContext) : base(webContext)
        {
        }

        public List<AnimalSpeciesData> GetRandomBeasts()
        {
            return _dbSet.OrderBy(r => EF.Functions.Random()).Take(START_PAGE_COUNT_ANIMALS).ToList();
        }

        public bool IsExists(string beastName)
        {
            return _dbSet.Any(animal => animal.AnimalSpeciesName.ToLower() == beastName.ToLower());
        }

        public AnimalSpeciesData GetBeastByName(string beastName)
        {
            return _dbSet.FirstOrDefault(animal => animal.AnimalSpeciesName.ToLower() == beastName.ToLower());
        }
    }
}
