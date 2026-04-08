using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Services.Interfaces
{
    public interface IMenuTypeGenerator
    {
        List<MenuTypeViewModel> GetMenuTypesFromFoodItems(List<FoodItemViewModel> foodItems, string sortMenuType);
    }
}