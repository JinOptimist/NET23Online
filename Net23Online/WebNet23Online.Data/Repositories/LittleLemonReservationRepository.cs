using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class LittleLemonReservationRepository : BaseRepository<LittleLemonData>, ILittleLemonReservationRepository
    {
        public LittleLemonReservationRepository(WebContext context) : base(context)
        {
        }
        
    }
}
