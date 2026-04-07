using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Services.Interfaces
{
    public interface FoodItemViewModelGenerator
    {
        List<FoodItemViewModel> GenerateFoodItems();
        void AddFoodItem(FoodItemViewModel foodItem);
    }
}
