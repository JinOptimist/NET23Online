using WebNet23Online.Data.Models;
using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public interface IHabitTrackerService
{
    public HabitTrackerViewModel GenerateHabitTracker(HabitTrackerData habitTrackerData);
    HabitData CreateHabit(HabitViewModel habit, int habitsCount);
    public bool IsHabitHasTitle(HabitViewModel habit);
    public bool IsHabitUnique(HabitTrackerViewModel model, HabitViewModel habit);
}