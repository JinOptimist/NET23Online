using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebNet23Online.Controllers.CustomAuthAttribute;
using WebNet23Online.Data;
using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.HabitTracker;
using WebNet23Online.Services;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers;

public class HabitTrackerController : Controller
{
    private IHabitService _habitService;
    private IHabitStatisticsService _statisticsService;
    private readonly IAuthService _authService;
    
    private IHabitRepository _habitRepository;
    private IHabitDoneDatesRepository _habitDoneDatesRepository;
    private IHabitDiaryRepository _diaryRepository;
    private IHabitTrackerProfileRepository _habitTrackerProfileRepository;
    private IUserRepository _userRepository;
    public HabitTrackerController(IHabitService habitService, IHabitStatisticsService statisticsService,
        IHabitRepository habitRepository, IHabitDiaryRepository diaryRepository,
        IHabitDoneDatesRepository habitDoneDatesRepository, IAuthService authService,
        IHabitTrackerProfileRepository habitTrackerProfileRepository, IUserRepository userRepository)
    {
        _habitService = habitService;
        _statisticsService = statisticsService;
        _habitRepository = habitRepository;
        _diaryRepository = diaryRepository;
        _habitDoneDatesRepository = habitDoneDatesRepository;
        _authService = authService;
        _habitTrackerProfileRepository = habitTrackerProfileRepository;
        _userRepository = userRepository;
    }

    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    [IsNotBlockedInTracker]
    public IActionResult HabitTracker()
    {
        var userId = _authService.GetUserId();
        var habitData = new List<HabitData>();
        
        if (!_habitRepository.UserHasHabits(userId))
        {
            habitData = _habitRepository.AddDefaultHabits(userId);
        }
        else
        {
            habitData = _habitRepository.GetByUserIdWithDatesForCurrentWeek(userId);
        }
        
        var model = _habitService.GenerateHabitTrackerWithResults(habitData);
        return View(model);
    } 
    
    [HttpGet]
    [IsNotBlockedInTracker]
    public IActionResult Statistics()
    {
        var userId = _authService.GetUserId();
        var habitData = _habitRepository.GetByUserIdWithDatesForCurrentMonth(userId);

        var model = _statisticsService.CreateStatisticsInfo(habitData);
        return View(model);
    } 
    
    [HttpGet]
    [IsNotBlockedInTracker]
    public IActionResult Diary(int month, int year)
    {
        //
        //уверены ли мы, что user not null, если есть атрибут [Authorize]?
        //
        var user = _authService.GetUser()!;
        var notesData = _diaryRepository.GetByUserAndMonth(user, year, month);
        var notes = notesData
            .ToDictionary(n => $"{n.Date.Year}-{n.Date.Month}-{n.Date.Day}",
                n => n.Content);
        
        return View();
    } 
    
    [HttpGet]
    [IsNotBlockedInTracker]
    public IActionResult Settings()
    {
        return View();
    }
    
    [HttpGet]
    [IsNotBlockedInTracker]
    public IActionResult CreateHabit()
    {
        var userId = _authService.GetUserId();
        var model = new HabitViewModel
        {
            UserId = userId
        };
        return View(model);
    }
    
    [HttpPost]
    [IsNotBlockedInTracker]
    public IActionResult CreateHabit(HabitViewModel  habit)
    {
        if (!ModelState.IsValid)
        {
            return View(habit);
        }
        
        var newHabit = _habitService.CreateHabit(habit);
        _habitRepository.Add(newHabit);
        return RedirectToAction(nameof(HabitTracker));
    }
    
    [HttpGet]
    [IsNotBlockedInTracker]
    public IActionResult DeleteHabit()
    {
        var userId = _authService.GetUserId();
        var habitData = _habitRepository.GetByUserId(userId);

        var model = _habitService.GenerateHabitList(habitData);
        return View(model);
    }

    [HttpPost]
    [IsNotBlockedInTracker]
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
    [IsNotBlockedInTracker]
    public IActionResult EditHabit()
    {
        var userId = _authService.GetUserId();
        var habitData = _habitRepository.GetByUserId(userId);
        var model = _habitService.GenerateHabitList(habitData);
        return View(model);
    }

    [HttpPost]
    [IsNotBlockedInTracker]
    public IActionResult EditHabit(HabitTrackerViewModel habitTracker)
    {
        var updateHabit = habitTracker.EditHabit;
        if (updateHabit.Id == 0 || !ModelState.IsValid)
        {
            return View(habitTracker);
        }
        
        _habitService.EditHabit(updateHabit);
        return RedirectToAction(nameof(HabitTracker));
    }

    [HttpPost]
    [IsNotBlockedInTracker]
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

    [HttpGet]
    [IsModerator]
    public IActionResult AdminPanel()
    {
        var habits = _habitRepository.GetAll();
    
        var model = new HabitAdminStatisticViewModel
        {
            AverageHabitsCount = habits.Any() 
                ? (int)habits.GroupBy(h => h.UserId).Average(g => g.Count()) 
                : 0,
            AveragePercentOfSuccess = 0, // пока заглушка
            TrendingHabits = habits
                .GroupBy(h => h.Title)
                .OrderByDescending(g => g.Count())
                .Take(5)
                .Select(g => g.Key)
                .ToList()
        };
    
        return View(model);
    }
    
    [HttpGet]
    [IsModerator]
    public IActionResult UserList()
    {
        var users = _userRepository.GetAll();
        var profiles = _habitTrackerProfileRepository.GetAll();
    
        var model = users.Select(u => new AdminUserViewModel
        {
            Id = u.Id,
            Name = u.Name,
            Role = u.Role,
            HabitsCount = u.Habits?.Count ?? 0,
            IsBlocked = profiles.FirstOrDefault(p => p.UserId == u.Id)?.IsBlocked ?? false
        }).ToList();
    
        return View(model);
    }
    
    [HttpPost]
    [IsModerator]
    public IActionResult ToggleBlock(int userId)
    {
        var profile = _habitTrackerProfileRepository.GetByUserId(userId);
        if (profile == null || !profile.IsBlocked)
            _habitTrackerProfileRepository.BlockUser(userId);
        else
            _habitTrackerProfileRepository.UnblockUser(userId);
        
        return RedirectToAction(nameof(UserList));
    }
    
}