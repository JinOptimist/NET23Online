using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces;

public interface IHabitRepository : IBaseRepository<HabitData>
{
    UserData GetTheFisrtUser();
    public List<HabitData> GetByUserId(int userId);
    List<HabitData> GetByUserIdWithDatesForCurrentWeek(int userId);
    List<HabitData> GetByUserIdWithDatesForCurrentMonth(int userId);
    void EditHabit(int id, string title, int monthGoal);
    bool IsHabitTitleUniq(string title);
}