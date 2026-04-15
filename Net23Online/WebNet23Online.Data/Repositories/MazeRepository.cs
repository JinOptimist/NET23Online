using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class MazeRepository : BaseRepository<MazeData>, IMazeRepository
    {
        public MazeRepository(WebContext context) : base(context) { }
    }
}
