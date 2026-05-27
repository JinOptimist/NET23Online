using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces.HabitTracker;

public interface IHabitChatRepository : IBaseRepository<HabitTrChatMessageData>
{
    public List<HabitTrChatMessageData> GetAllWithUsers();
}