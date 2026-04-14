using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class AnimeGirlRepository : BaseRepository<AnimeGirlData>, IAnimeGirlRepository
    {
        public AnimeGirlRepository(WebContext webContext) : base(webContext) { }

        public override void Add(AnimeGirlData model)
        {
            if (model.Name == model.Description)
            {
                throw new Exception("Be more creative");
            }

            base.Add(model);
        }

        public bool IsNameFree(string name)
        {
            return !_dbSet.Any(x => x.Name == name);
        }
    }
}
