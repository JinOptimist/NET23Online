using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class RockLegendsRepository : BaseRepository<RockLegendsData>, IRockLegendsRepository
    {
        public RockLegendsRepository(WebContext webContext) : base(webContext) { }

        public void Update(RockLegendsData model)
        {
            _context.Update(model);
            _context.SaveChanges();
        }
    }
}
