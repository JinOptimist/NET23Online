using WebNet23Online.Data.Models;
using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public class HabitService : IHabitService
{
    public HabitTrackerViewModel GenerateHabitTracker(List<HabitData> habitData)
    {
        var modelHabitTracker = new HabitTrackerViewModel()
        {
            Habits = habitData.Select(habit => new HabitViewModel
            {
                Id = habit.Id,
                Title = habit.Title,
                WeekResults = GenerateWeekResult(habit.CompletedDates
                    .Select(x=> x.DateOfCompletion)
                    .ToList())
                
            }).ToList(),
        };
        return modelHabitTracker;
    }

    private List<bool> GenerateWeekResult(List<DateTime> results)
    {
        var today = DateTime.Today;
        int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
        var weekStart = today.AddDays(-1*diff);
        
        var weekResults = results
            .Select(r => r.Date)
            .ToHashSet();   

        return Enumerable.Range(0, 7)
            .Select( day => weekResults
                .Contains(weekStart.AddDays(day)))
            .ToList();
    }
    
    public void EnsureDefaultHabits(UserData user, List<HabitData> habitData)
    {
        if (habitData.Any())
        {
            return;
        }

        var defaultHabits = new List<string> { "Спорт 30 мин", "Программирование 1 час", "Вода 2л" };
    
        foreach (var title in defaultHabits)
        {
            habitData.Add(new HabitData
            {
                Title = title,
                User = user,
            });
        }
    }
    public HabitData CreateHabit(HabitViewModel modelHabit, UserData user)
    {
        //поймет ли навигационное поле, что я имею ввиду?
        var habit = new HabitData()
        {
            Title = modelHabit.Title,
            CompletedDates = new List<HabitDoneDatesData>(),
            User = user,
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
}