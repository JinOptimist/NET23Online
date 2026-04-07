using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Services.Interfaces
{
    public interface IFoodItemGenerator
    {
        List<FoodItemViewModel> GenerateFoodItems();
        List<MenuTypeViewModel> GetMenuTypes(/*string sortMenuType*/);
        void AddFoodItem(FoodItemViewModel foodItem);
    }
}
