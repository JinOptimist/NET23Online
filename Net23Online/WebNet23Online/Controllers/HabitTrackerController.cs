using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data;
using WebNet23Online.Models.HabitTracker;
using WebNet23Online.Services;

namespace WebNet23Online.Controllers;

public class HabitTrackerController : Controller
{
    private IHabitTrackerService _habitService;
    private IHabitStatisticsService _statisticsService;
    
    private WebContext _webContext;

    public HabitTrackerController(IHabitTrackerService habitService, IHabitStatisticsService statisticsService,  WebContext webContext)
    {
        _habitService = habitService;
        _statisticsService = statisticsService;
        _webContext = webContext;
    }
    public IActionResult Index()
    {
        var habitTrackerData = _webContext.HabitTracker
            .Include(h => h.Habits)
            .FirstOrDefault();

        var model = _habitService.GenerateHabitTracker(habitTrackerData);
        return View(model);
    } 
    
    [HttpGet]
    public IActionResult Statistics()
    {
        var habitTrackerData = _webContext.HabitTracker
            .Include(h => h.Habits)
            .FirstOrDefault();

        var model = _habitService.GenerateHabitTracker(habitTrackerData);
        
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
        var habitTrackerData = _webContext.HabitTracker
            .Include(h => h.Habits)
            .FirstOrDefault();

        var model = _habitService.GenerateHabitTracker(habitTrackerData);
        
        if (_habitService.IsHabitHasTitle(habit)
            || _habitService.IsHabitUnique(model, habit))
        {
            return RedirectToAction(nameof(Index));
        }
        
        var newHabit = _habitService.CreateHabit(habit, habitTrackerData.Habits.Count);
        habitTrackerData.Habits.Add(newHabit);
        _webContext.SaveChanges();
        
        return RedirectToAction(nameof(Index));
    }
}