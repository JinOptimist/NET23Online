using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.Repositories.Interfaces
{
    public interface IMenuRepository : IBaseRepository<MenuData>
    {
        List<MenuData> GetAllIncludeFoodItemsWithIngredients(string sortMenuName);
    }
}