using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;

namespace WebNet23Online.Data.Repositories
{
    public class FoodItemRepository : BaseRepository<FoodItemData>, IFoodItemRepository
    {
        public FoodItemRepository(WebContext context) : base(context) { }

        public List<FoodItemData> GetAllIncludeMenuAndIngredients()
        {
            var allFoods = _dbSet.Include(x => x.MenuData).Include(x => x.IngredientsList);

            return allFoods.ToList();
        }
        
    }
}
