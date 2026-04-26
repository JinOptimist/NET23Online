using WebNet23Online.Data.Models;
using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public interface IHabitStatisticsService
{
    HabitTrackerViewModel CreateStatisticsInfo(List<HabitData> habitData);
}