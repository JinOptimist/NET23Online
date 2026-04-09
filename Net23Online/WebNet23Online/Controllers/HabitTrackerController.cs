using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Controllers;

public class HabitTrackerController : Controller
{
    //статик это плохо
    private static HabitTrackerViewModel _habitsTraker  = new HabitTrackerViewModel();
    
    private static List<HabitViewModel> _allHabits = new List<HabitViewModel>
    {
        new HabitViewModel { Title = "Спорт 30 мин", ColorOfDot = "pink" },
        new HabitViewModel { Title = "Английский 20 мин", ColorOfDot = "blue"},
        new HabitViewModel { Title = "Программирование 1 час",  ColorOfDot = "green"},
        new HabitViewModel { Title = "Вода 2л", ColorOfDot = "purple"},
    };
    
    
    public IActionResult Index()
    {
        var model = _habitsTraker;
        model.Habits = _allHabits;
        return View(model);
    } 
    
    [HttpGet]
    public IActionResult Statistics()
    {
        var  model = _habitsTraker;
        model.Habits = _allHabits;

        foreach (var habit in _allHabits)
        {
            var doneCount = habit.WeekResults.Count(x => x);
            var percent = (float)doneCount / 7 * 100;
            
            habit.DoneCount = doneCount;
            habit.Percent = percent;
        }
        return View(model);
    } 
    
    [HttpGet]
    public IActionResult Diary()
    {
        return View();
    } 
    
    [HttpGet]
    public IActionResult CreateHabit()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult CreateHabit(HabitViewModel  habit)
    {
        if (string.IsNullOrEmpty(habit.Title) 
            || _allHabits.Any(h => h.Title == habit.Title))
        {
            return RedirectToAction(nameof(Index));
        }
        
        var availibleColors = new[] { "pink", "blue", "green", "purple" };
        
        var indexOfColorForHabit = _allHabits.Count % availibleColors.Length; 
        
        habit.ColorOfDot = availibleColors[indexOfColorForHabit];
        _allHabits.Add(habit);
        
        return RedirectToAction(nameof(Index));
    }
}