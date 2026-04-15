using WebNet23Online.Data.Models;
using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public class HabitTrackerService : IHabitTrackerService
{
    private HabitTrackerViewModel _habitTracker;

    private List<HabitViewModel> _allHabits;
    
    public HabitTrackerViewModel GenerateHabitTracker(HabitTrackerData habitTrackerData)
    {
        var modelHabitTracker = new HabitTrackerViewModel()
        {
            UserName = habitTrackerData.UserName,
            Habits = habitTrackerData.Habits.Select(habit => new HabitViewModel
            {
                Id = habit.Id,
                DoneCount = habit.DoneCount,
                Percent = habit.Percent,
                Title = habit.Title,
                WeekResults = habit.WeekResults,
                ColorOfDot = habit.ColorOfDot,
            }).ToList(),
        };
        return modelHabitTracker;
    }

    public HabitData CreateHabit(HabitViewModel modelHabit, int habitsCount)
    {
        var availibleColors = new[] { "pink", "blue", "green", "purple" };
        
        var indexOfColorForHabit = habitsCount % availibleColors.Length; 
        
        var habit = new HabitData()
        {
            ColorOfDot = availibleColors[indexOfColorForHabit],
            DoneCount = modelHabit.DoneCount,
            Percent = modelHabit.Percent,
            Title = modelHabit.Title,
            WeekResults = modelHabit.WeekResults?.Count == 7 
                ? modelHabit.WeekResults 
                : new List<bool> { false, false, false, false, false, false, false },
        };

        return habit;
    }

    public bool IsHabitHasTitle(HabitViewModel  habit)
    {
        return string.IsNullOrEmpty(habit.Title);
    }
    
    public bool IsHabitUnique(HabitTrackerViewModel model, HabitViewModel  habit)
    {
        return model.Habits.Any(h => h.Title == habit.Title);
    }

    public void ChangeDayPointStatus(HabitData habit, int  dayIndex)
    {
        habit.WeekResults[dayIndex] = !habit.WeekResults[dayIndex];
    }
}