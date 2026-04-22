using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data;
using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.HabitTracker;
using WebNet23Online.Services;

namespace WebNet23Online.Controllers;

public class HabitTrackerController : Controller
{
    private IHabitService _habitService;
    private IHabitStatisticsService _statisticsService;
    
    private IHabitRepository _habitRepository;
    private IUserRepository _userRepository;
    public HabitTrackerController(IHabitService habitService, IHabitStatisticsService statisticsService,
        IHabitRepository habitRepository, IUserRepository userRepository)
    {
        _habitService = habitService;
        _statisticsService = statisticsService;
        _habitRepository = habitRepository;
        _userRepository = userRepository;
    }
    public IActionResult Index()
    {
        //пока нет авторизации
        var user = _habitRepository.Authorise();
        var habitData = _habitRepository.GetByUserId(user);
        
        _habitService.EnsureDefaultHabits(user);
        _userRepository.Update(user);
        
        var model = _habitService.GenerateHabitTracker(habitData);
        return View(model);
    } 
    
    [HttpGet]
    public IActionResult Statistics()
    {
        //пока нет авторизации
        var user = _habitRepository.Authorise();
        var habitData = _habitRepository.GetByUserId(user);

        var model = _habitService.GenerateHabitTracker(habitData);
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
        //пока нет авторизации
        var user = _habitRepository.Authorise();
        var habitData = _habitRepository.GetByUserId(user);
        
        var model = _habitService.GenerateHabitTracker(habitData);
        
        if (_habitService.IsHabitHasTitle(habit)
            || _habitService.IsHabitUnique(model, habit))
        {
            return RedirectToAction(nameof(Index));
        }
        
        var newHabit = _habitService.CreateHabit(habit, user);
        _habitRepository.Add(newHabit);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult TogglePoint(int habitId, int dayIndex)
    {
        var habit = _habitRepository.Get(habitId);
        if (habit == null)
        {
            return RedirectToAction(nameof(Index));
        }
        
        _habitRepository.ChangeDayPointStatus(habit, dayIndex);
        _habitRepository.Update(habit);
        return RedirectToAction(nameof(Index));
    }
}