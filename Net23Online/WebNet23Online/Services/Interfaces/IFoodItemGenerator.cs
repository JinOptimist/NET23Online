using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Services.Interfaces
{
    public interface IFoodItemGenerator
    {
        List<FoodItemViewModel> GenerateFoodItems();
        void AddFoodItem(FoodItemViewModel foodItem);
    }
}
