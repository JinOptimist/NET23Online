using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public class HabitTrackerService : IHabitTrackerService
{
    private HabitTrackerViewModel _habitTracker;

    private List<HabitViewModel> _allHabits;
    
    public HabitTrackerViewModel GetHabitTracker()
    {
        if (_habitTracker is null)
        {
            _habitTracker = new HabitTrackerViewModel();
            _habitTracker.Habits = GetAllHabits();
        }
        
        return _habitTracker;
    }

    private List<HabitViewModel> GetAllHabits()
    {
        if (_allHabits is null)
        {
            _allHabits = new List<HabitViewModel>()
            {
                new HabitViewModel { Title = "Спорт 30 мин", ColorOfDot = "pink" },
                new HabitViewModel { Title = "Английский 20 мин", ColorOfDot = "blue" },
                new HabitViewModel { Title = "Программирование 1 час", ColorOfDot = "green" },
                new HabitViewModel { Title = "Вода 2л", ColorOfDot = "purple" },
            };
        }
        return _allHabits;
    }

    public void CreateHabit(HabitViewModel habit)
    {
        var availibleColors = new[] { "pink", "blue", "green", "purple" };
        
        var indexOfColorForHabit = _allHabits.Count % availibleColors.Length; 
        
        habit.ColorOfDot = availibleColors[indexOfColorForHabit];
        _allHabits.Add(habit);
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