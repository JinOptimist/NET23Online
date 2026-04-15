using Microsoft.EntityFrameworkCore;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface IFoodItemRepository : IBaseRepository<FoodItemData>
    {
    }
}