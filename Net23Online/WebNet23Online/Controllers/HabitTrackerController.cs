using Microsoft.AspNetCore.Authorization;
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
        return View();
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult HabitTracker()
    {
        //пока нет авторизации
        var user = _habitRepository.GetTheFisrtUser();
        var habitData = new List<HabitData>();
        
        if (!_habitRepository.UserHasHabits(user.Id))
        {
            habitData = _habitRepository.AddDefaultHabits(user.Id);
        }
        else
        {
            habitData = _habitRepository.GetByUserIdWithDatesForCurrentWeek(user.Id);
        }
        var model = _habitService.GenerateHabitTrackerWithResults(habitData);
        return View(model);
    } 
    
    [HttpGet]
    [Authorize]
    public IActionResult Statistics()
    {
        //пока нет авторизации
        var user = _habitRepository.GetTheFisrtUser();
        var habitData = _habitRepository.GetByUserIdWithDatesForCurrentMonth(user.Id);

        var model = _statisticsService.CreateStatisticsInfo(habitData);
        
        return View(model);
    } 
    
    [HttpGet]
    [Authorize]
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
    [Authorize]
    public IActionResult Settings()
    {
        return View();
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult CreateHabit()
    {
        var user = _habitRepository.GetTheFisrtUser();
        var model = new HabitViewModel
        {
            UserId = user.Id
        };
        return View(model);
    }
    
    [HttpPost]
    [Authorize]
    public IActionResult CreateHabit(HabitViewModel  habit)
    {
        if (!ModelState.IsValid)
        {
            return View(habit);
        }
        
        //пока нет авторизации
        var habitTitles = _habitRepository.GetTitlesByUserId(habit.UserId);
        
        if (!_habitService.IsHabitHasTitle(habit)
            || !_habitService.IsHabitUnique(habitTitles, habit.Title))
        {
            return RedirectToAction(nameof(HabitTracker));
        }
        
        var newHabit = _habitService.CreateHabit(habit);
        _habitRepository.Add(newHabit);
        return RedirectToAction(nameof(HabitTracker));
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult DeleteHabit()
    {
        var user = _habitRepository.GetTheFisrtUser();
        var habitData = _habitRepository.GetByUserId(user.Id);

        var model = _habitService.GenerateHabitList(habitData);
        return View(model);
    }

    [HttpPost]
    [Authorize]
    public IActionResult DeleteHabit(int habitId)
    {
        if (habitId == 0)
        {
            return RedirectToAction(nameof(DeleteHabit));
        }
        
        var habitData = _habitRepository.Get(habitId);
        if (habitData == null)
        {
            return RedirectToAction(nameof(DeleteHabit));
        }
        
        _habitRepository.Remove(habitData);
        return RedirectToAction(nameof(HabitTracker));
    }
    
    [HttpGet]
    [Authorize]
    public IActionResult EditHabit()
    {
        var user = _habitRepository.GetTheFisrtUser();
        var habitData = _habitRepository.GetByUserId(user.Id);
        var model = _habitService.GenerateHabitList(habitData);
        return View(model);
    }

    [HttpPost]
    [Authorize]
    public IActionResult EditHabit(HabitTrackerViewModel habitTracker)
    {
        var updateHabit = habitTracker.EditHabit;
        if (updateHabit.Id == 0)
        {
            return View(habitTracker);
        }

        if (!ModelState.IsValid)
        {
            return View(habitTracker);
        }
        
        _habitService.EditHabit(updateHabit);
        return RedirectToAction(nameof(HabitTracker));
    }

    [HttpPost]
    [Authorize]
    public IActionResult TogglePoint(int habitId, int dayOfWeek)
    {
        var habit = _habitRepository.Get(habitId);
        if (habit == null)
        {
            return RedirectToAction(nameof(HabitTracker));
        }
        
        _habitDoneDatesRepository.ChangeDayPointStatus(habit.Id, dayOfWeek);
        return RedirectToAction(nameof(HabitTracker));
    }
}