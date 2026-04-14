using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class FoodItemRepository : BaseRepository<FoodItemData>, IFoodItemRepository
    {
        public FoodItemRepository(WebContext context) : base(context)
        {
        }
        public void SaveChanges()
        {
            _context.SaveChanges();
        }
    }
}
