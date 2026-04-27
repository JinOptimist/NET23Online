using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.HabitTracker;

namespace WebNet23Online.Services;

public class HabitService : IHabitService
{
    private readonly IHabitRepository _habitRepository;

    public HabitService(IHabitRepository _habitRepository)
    {
        this._habitRepository = _habitRepository;
    }
    
    public HabitViewModel GenerateHabit(HabitData habit)
    {
        return new HabitViewModel
        {
            Id = habit.Id,
            Title = habit.Title,
            MonthGoal = habit.MonthGoal,
            UserId = habit.User.Id
        };
    }
    public HabitTrackerViewModel GenerateHabitList(List<HabitData> habitData)
    {
        return new HabitTrackerViewModel
        {
            Habits = habitData.Select(habit => new HabitViewModel
            {
                Id = habit.Id,
                Title = habit.Title,
                MonthGoal = habit.MonthGoal,
                UserId = habit.User.Id
            }).ToList()
        };
    }
    public HabitTrackerViewModel GenerateHabitTrackerWithResults(List<HabitData> habitData)
    {
        var modelHabitTracker = new HabitTrackerViewModel()
        {
            Habits = habitData.Select(habit => new HabitViewModel
            {
                Id = habit.Id,
                Title = habit.Title,
                MonthGoal = habit.MonthGoal,
                UserId = habit.User.Id,
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
    public HabitData CreateHabit(HabitViewModel modelHabit)
    {
        //поймет ли навигационное поле, что я имею ввиду?
        var habit = new HabitData()
        {
            Title = modelHabit.Title,
            MonthGoal = modelHabit.MonthGoal,
            CompletedDates = new List<HabitDoneDatesData>(),
            UserId = modelHabit.UserId,
        };

        return habit;
    }
    public bool IsHabitHasTitle(HabitViewModel  habit)
    {
        return !string.IsNullOrEmpty(habit.Title);
    }
    public bool IsHabitUnique(List<string> habitTitles, string habitTitle)
    {
        return !habitTitles.Contains(habitTitle);
    }
    public void EditHabit(HabitViewModel updateHabit)
    {
        var habitData = new HabitData
        {
            Id = updateHabit.Id,
            Title = updateHabit.Title,
            MonthGoal = updateHabit.MonthGoal,
        };
    
        _habitRepository.EditHabit(habitData);
    }
}