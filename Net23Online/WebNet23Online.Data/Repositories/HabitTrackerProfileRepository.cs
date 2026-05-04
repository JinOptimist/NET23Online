using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories;

public class HabitTrackerProfileRepository : BaseRepository<HabitTrackerProfileData>, IHabitTrackerProfileRepository
{
    public HabitTrackerProfileRepository(WebContext context) : base(context) { }

    public HabitTrackerProfileData? GetByUserId(int userId)
    {
        return _dbSet.FirstOrDefault(x => x.UserId == userId);
    }

    public void BlockUser(int userId)
    {
        var profile = GetByUserId(userId);
        profile.IsBlocked = true;
        Update(profile);
    }

    public void UnblockUser(int userId)
    {
        var profile = GetByUserId(userId);
        profile.IsBlocked = false;
        Update(profile);
    }
}