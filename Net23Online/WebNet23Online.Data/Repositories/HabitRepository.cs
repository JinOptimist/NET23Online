using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces;

public class HabitRepository : BaseRepository<HabitData>, IHabitRepository
{
    private IUserRepository _userRepository;

    public HabitRepository(WebContext webContext, IUserRepository userRepository) : base(webContext)
    {
        _userRepository = userRepository;
    }

    public override HabitData? Get(int id)
    {
        return _dbSet
            .Include(x => x.Results)
            .FirstOrDefault(x => x.Id == id);
    }
    //пока нет авторизации
    public UserData Authorise()
    {
        if (!_userRepository.Any())
        {
            _userRepository.Add(new UserData()
            {
                Name = "Test User",
                Role = UserRole.User
                
            });
        }
        var user = _userRepository.GetFirst();
        return user;
    }


    public List<HabitData> GetByUserId(UserData user)
    {
        return _dbSet
            .Include(x => x.Results)
            .Where(x => x.User.Id == user.Id)
            .ToList();
    }

    public void ChangeDayPointStatus(HabitData habit, int dayIndex)
    {
        var weekStart = DateTime.Today.AddDays(-(int)DateTime.Today.DayOfWeek + 1);
        var targetDate = weekStart.AddDays(dayIndex);
    
        var result = habit.Results.FirstOrDefault(r => r.Date.Date == targetDate);
    
        if (result == null)
        {
            habit.Results.Add(new HabitDoneDatesData 
                { Date = targetDate});
        }
        else
        {
            habit.Results.Remove(result);
        }
    }
}