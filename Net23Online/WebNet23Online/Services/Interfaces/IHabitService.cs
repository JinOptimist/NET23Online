using WebNet23Online.Data.Models;
using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public interface IHabitService
{
    HabitTrackerViewModel GenerateHabitTracker(List<HabitData> habitData);
    void EnsureDefaultHabits(UserData user);
    HabitData CreateHabit(HabitViewModel modelHabit, UserData user);
    bool IsHabitHasTitle(HabitViewModel habit);
    bool IsHabitUnique(HabitTrackerViewModel model, HabitViewModel habit);
}