using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces;

public class HabitRepository : BaseRepository<HabitData>, IHabitRepository
{
    public HabitRepository(WebContext webContext) : base(webContext) { }
    
    //пока нет авторизации
    public UserData GetTheFisrtUser()
    {
        if (!_context.Users.Any())
        {
            _context.Users.Add(new UserData()
            {
                Name = "Test User",
                Role = UserRole.User
                
            });
        }
        return _context.Users.First();
    }

    public List<HabitData> GetByUserId(int userId)
    {
        return _dbSet
            .Where(x => x.User.Id == userId)
            .ToList();
    }
    
    public List<HabitData> GetByUserIdWithDatesForCurrentWeek(int userId)
    {
        var today = DateTime.Today;
        int diff = (7 + (today.DayOfWeek - DayOfWeek.Monday)) % 7;
        var weekStart = today.AddDays(-1 * diff);
        
        return _dbSet
            .Include(x => x.CompletedDates
                .Where(d => d.DateOfCompletion >= weekStart && d.DateOfCompletion < weekStart.AddDays(7)))
            .Where(x => x.User.Id == userId)
            .ToList();
    }
    
    public List<HabitData> GetByUserIdWithDatesForCurrentMonth(int userId)
    {
        var today = DateTime.Today;
        var monthStart = new DateTime(today.Year, today.Month, 1);
        var monthEnd = monthStart.AddMonths(1);
        
        return _dbSet
            .Include(x => x.CompletedDates
                .Where(d => d.DateOfCompletion >= monthStart && d.DateOfCompletion < monthEnd))
            .Where(x => x.User.Id == userId)
            .ToList();
    }

    public void EditHabit(int id, string title, int monthGoal)
    {
        var habit = _dbSet.FirstOrDefault(x => x.Id == id);
        if (habit == null)
        {
            return;
        }
        habit.Title = title;
        habit.MonthGoal = monthGoal;
        Update(habit);
    }
}