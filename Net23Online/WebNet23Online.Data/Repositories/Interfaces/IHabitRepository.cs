using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces;

public interface IHabitRepository : IBaseRepository<HabitData>
{
    UserData Authorise();
    public List<HabitData> GetByUserId(UserData user);
    public void ChangeDayPointStatus(HabitData habit, int dayIndex);
}