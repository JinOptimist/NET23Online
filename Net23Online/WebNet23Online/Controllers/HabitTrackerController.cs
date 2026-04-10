using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.HabitTracker;
using WebNet23Online.Services;

namespace WebNet23Online.Controllers;

public class HabitTrackerController : Controller
{
    private IHabitTrackerService _habitService;
    private IHabitStatisticsService _statisticsService;

    public HabitTrackerController(IHabitTrackerService habitService, IHabitStatisticsService statisticsService)
    {
        _habitService = habitService;
        _statisticsService = statisticsService;
    }
    public IActionResult Index()
    {
        var model = _habitService.GetHabitTracker();
        return View(model);
    } 
    
    [HttpGet]
    public IActionResult Statistics()
    {
        var model = _habitService.GetHabitTracker();
        _statisticsService.CreateStatisticsInfo(model);
        
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
        var model = _habitService.GetHabitTracker();
        if (_habitService.IsHabitHasTitle(habit)
            || _habitService.IsHabitUnique(model, habit))
        {
            return RedirectToAction(nameof(Index));
        }
        
        _habitService.CreateHabit(habit);
        
        return RedirectToAction(nameof(Index));
    }
}