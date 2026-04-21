using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces;

public class HabitTrackerRepository : BaseRepository<HabitTrackerData>, IHabitTrackerRepository
{
    public HabitTrackerRepository(WebContext webContext) : base(webContext) { }

    public override HabitTrackerData? Get(int id)
    {
        return _context.Set<HabitTrackerData>()
            .Include(h => h.Habits)
            .FirstOrDefault(x => x.Id == id);
    }
}