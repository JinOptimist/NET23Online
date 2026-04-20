using WebNet23Online.Data.Models;
using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public interface IHabitTrackerService
{
    HabitTrackerViewModel GenerateHabitTracker(HabitTrackerData habitTrackerData);
    HabitData CreateHabit(HabitViewModel habit, int habitsCount);
    bool IsHabitHasTitle(HabitViewModel habit);
    bool IsHabitUnique(HabitTrackerViewModel model, HabitViewModel habit);
    void ChangeDayPointStatus(HabitData habit, int dayIndex);
}