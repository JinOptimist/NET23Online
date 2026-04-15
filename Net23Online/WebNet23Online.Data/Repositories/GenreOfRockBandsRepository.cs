using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class GenreOfRockBandsRepository : BaseRepository<GenreOfRockBands>, IGenreOfRockBandsRepository
    {
        public GenreOfRockBandsRepository(WebContext context) : base(context) { }
    }
}

