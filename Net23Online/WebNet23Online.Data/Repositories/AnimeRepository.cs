using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class AnimeRepository : BaseRepository<AnimeData>, IAnimeRepository
    {
        public AnimeRepository(WebContext context) : base(context)
        {
        }
    }
}
