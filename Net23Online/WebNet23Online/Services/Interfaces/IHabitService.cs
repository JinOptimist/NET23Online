using WebNet23Online.Data.Models;
using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public interface IHabitService
{
    HabitTrackerViewModel GenerateHabitList(List<HabitData> habitData);
    HabitTrackerViewModel GenerateHabitTrackerWithResults(List<HabitData> habitData);
    void EnsureDefaultHabits(UserData user, List<HabitData> habitData);
    HabitData CreateHabit(HabitViewModel modelHabit, UserData user);
    bool IsHabitHasTitle(HabitViewModel habit);
    bool IsHabitUnique(List<string> habitTitles, HabitViewModel  habit);
}