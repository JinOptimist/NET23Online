using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.HabitTracker;
using WebNet23Online.Services;

namespace WebNet23Online.Controllers;

public class HabitTrackerController : Controller
{
    private IHabitTrackerService _habitService;
    private IHabitStatisticsService _statisticsService;
    
    private IHabitTrackerRepository _habitTrackerRepository;
    public HabitTrackerController(IHabitTrackerService habitService, IHabitStatisticsService statisticsService,  IHabitTrackerRepository habitTrackerRepository)
    {
        _habitService = habitService;
        _statisticsService = statisticsService;
        _habitTrackerRepository = habitTrackerRepository;
    }
    public IActionResult Index()
    {
        //пока нет авторизации, так что только одно id
        var habitTrackerData = _habitTrackerRepository.Get(1);

        var model = _habitService.GenerateHabitTracker(habitTrackerData);
        return View(model);
    } 
    
    [HttpGet]
    public IActionResult Statistics()
    {
        var habitTrackerData = _habitTrackerRepository.Get(1);

        var model = _habitService.GenerateHabitTracker(habitTrackerData);
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
        var habitTrackerData = _habitTrackerRepository.Get(1);

        var model = _habitService.GenerateHabitTracker(habitTrackerData);
        
        if (_habitService.IsHabitHasTitle(habit)
            || _habitService.IsHabitUnique(model, habit))
        {
            return RedirectToAction(nameof(Index));
        }
        
        var newHabit = _habitService.CreateHabit(habit, habitTrackerData.Habits.Count);
        habitTrackerData.Habits.Add(newHabit);
        _habitTrackerRepository.Save(habitTrackerData);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult TogglePoint(int habitId, int dayIndex)
    {
        var habitTrackerData = _habitTrackerRepository.Get(1);

        var habit = habitTrackerData.Habits.FirstOrDefault(h => h.Id == habitId);
        if (habit != null)
        {
            _habitService.ChangeDayPointStatus(habit, dayIndex);
            _habitTrackerRepository.Save(habitTrackerData);
        }
        return RedirectToAction(nameof(Index));
    }
}