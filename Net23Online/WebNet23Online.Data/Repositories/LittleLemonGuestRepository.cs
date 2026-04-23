using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class LittleLemonGuestRepository : BaseRepository<LittleLemonGuestData>, ILittleLemonGuestRepository
    {
        public LittleLemonGuestRepository(WebContext context) : base(context)
        {
        }
    }
}
