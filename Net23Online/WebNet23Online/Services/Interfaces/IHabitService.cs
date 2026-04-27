using WebNet23Online.Data.Models;
using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public interface IHabitService
{
    HabitViewModel GenerateHabit(HabitData habit);
    HabitTrackerViewModel GenerateHabitList(List<HabitData> habitData);
    HabitTrackerViewModel GenerateHabitTrackerWithResults(List<HabitData> habitData);
    HabitData CreateHabit(HabitViewModel modelHabit);
    bool IsHabitHasTitle(HabitViewModel habit);
    bool IsHabitUnique(List<string> habitTitles,  string habitTitle);
    void EditHabit(HabitViewModel updateHabit);
}