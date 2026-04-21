using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces.DelightBistro
{
    public interface IFoodItemRepository : IDelightBistro<FoodItemData>
    {
        List<FoodItemData> GetAllIncludeMenuAndIngredients();
    }
}