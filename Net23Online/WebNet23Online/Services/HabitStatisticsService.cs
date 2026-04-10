using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public class HabitStatisticsService : IHabitStatisticsService
{
    public void CreateStatisticsInfo(HabitTrackerViewModel model)
    {
        foreach (var habit in model.Habits)
        {
            var doneCount = habit.WeekResults.Count(x => x);
            var percent = (float)doneCount / 7 * 100;
            
            habit.DoneCount = doneCount;
            habit.Percent = percent;
        }
    }
}