using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces;

public interface IHabitTrackerProfileRepository : IBaseRepository<HabitTrackerProfileData>
{
    HabitTrackerProfileData? GetByUserId(int userId);
    void BlockUser(int userId);
    void UnblockUser(int userId);
}