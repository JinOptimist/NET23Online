using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data;
using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.HabitTracker;
using WebNet23Online.Services;

namespace WebNet23Online.Controllers;

public class HabitTrackerController : Controller
{
    private IHabitService _habitService;
    private IHabitStatisticsService _statisticsService;
    
    private IHabitRepository _habitRepository;
    private IHabitDoneDatesRepository _habitDoneDatesRepository;
    private IUserRepository _userRepository;
    private IHabitDiaryRepository _diaryRepository;
    public HabitTrackerController(IHabitService habitService, IHabitStatisticsService statisticsService,
        IHabitRepository habitRepository, IUserRepository userRepository, IHabitDiaryRepository diaryRepository,
        IHabitDoneDatesRepository habitDoneDatesRepository)
    {
        _habitService = habitService;
        _statisticsService = statisticsService;
        _habitRepository = habitRepository;
        _userRepository = userRepository;
        _diaryRepository = diaryRepository;
        _habitDoneDatesRepository = habitDoneDatesRepository;
    }
    public IActionResult Index()
    {
        //пока нет авторизации
        var user = _habitRepository.GetTheFisrtUser();
        var habitData = _habitRepository.GetByUserIdWithDatesForCurrentWeek(user.Id);
        
        _habitService.EnsureDefaultHabits(user, habitData);
        _userRepository.Update(user);
        
        var model = _habitService.GenerateHabitTrackerWithResults(habitData);
        return View(model);
    } 
    
    [HttpGet]
    public IActionResult Statistics()
    {
        //пока нет авторизации
        var user = _habitRepository.GetTheFisrtUser();
        var habitData = _habitRepository.GetByUserIdWithDatesForCurrentMonth(user.Id);

        var model = _statisticsService.CreateStatisticsInfo(habitData);
        
        return View(model);
    } 
    
    [HttpGet]
    public IActionResult Diary(int month, int year)
    {
        var user = _habitRepository.GetTheFisrtUser();
        var notesData = _diaryRepository.GetByUserAndMonth(user, year, month);
        var notes = notesData
            .ToDictionary(n => $"{n.Date.Year}-{n.Date.Month}-{n.Date.Day}",
                n => n.Content);
        
        return View();
    } 

    [HttpGet]
    public IActionResult Settings()
    {
        var user = _habitRepository.GetTheFisrtUser();
        var habitData = _habitRepository.GetByUserId(user.Id);
        var model = _habitService.GenerateHabitList(habitData);
        
        return View(model);
    }
    
    [HttpPost]
    public IActionResult CreateHabit(HabitViewModel  habit)
    {
        //пока нет авторизации
        var user = _habitRepository.GetTheFisrtUser();
        var habitTitles = _habitRepository
            .GetByUserId(user.Id)
            .Select(x => x.Title)
            .ToList();
        
        if (_habitService.IsHabitHasTitle(habit)
            || _habitService.IsHabitUnique(habitTitles, habit))
        {
            return RedirectToAction(nameof(Index));
        }
        
        var newHabit = _habitService.CreateHabit(habit, user);
        _habitRepository.Add(newHabit);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult DeleteHabit(HabitViewModel habit)
    {
        var habitData = _habitRepository.Get(habit.Id);
        _habitRepository.Remove(habitData);
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult EditHabit(HabitViewModel habit)
    {
        _habitRepository.EditHabit(habit.Id,  habit.Title, habit.MonthGoal );
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    public IActionResult TogglePoint(int habitId, int dayOfWeek)
    {
        var habit = _habitRepository.Get(habitId);
        if (habit == null)
        {
            return RedirectToAction(nameof(Index));
        }
        
        _habitDoneDatesRepository.ChangeDayPointStatus(habit.Id, dayOfWeek);
        return RedirectToAction(nameof(Index));
    }
}