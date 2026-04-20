using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public interface IHabitStatisticsService
{
    void CreateStatisticsInfo(HabitTrackerViewModel model);
}