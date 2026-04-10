using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public interface IHabitTrackerService
{
    HabitTrackerViewModel GetHabitTracker();
    void CreateHabit(HabitViewModel habit);
    public bool IsHabitHasTitle(HabitViewModel habit);
    public bool IsHabitUnique(HabitTrackerViewModel model, HabitViewModel habit);
}