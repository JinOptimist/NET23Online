using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class UserRepository : BaseRepository<UserData>, IUserRepository
    {
        public UserRepository(WebContext context) : base(context) { }
        
        public UserData GetFirst()
        {
            return _dbSet
                .Include(x => x.Habits)
                .First();
        }
    }
}
