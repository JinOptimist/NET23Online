using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Data.Repositories.Interfaces.HabitTracker;

namespace WebNet23Online.Data.Repositories;

public class HabitChatRepository : BaseRepository<HabitTrChatMessageData>, IHabitChatRepository
{
    public HabitChatRepository(WebContext webContext) : base(webContext)
    {
    }
    
    public List<HabitTrChatMessageData> GetAllWithUsers()
    {
        return _dbSet
            .Include(x => x.User)
            .ToList();
    }
}