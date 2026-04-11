using WebNet23Online.Data.Models;
using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Services.Interfaces
{
    public interface IFoodItemGenerator
    {
        List<FoodItemViewModel> GenerateFoodItems();
        List<FoodItemViewModel> GenerateFoodItems(List<FoodItemData> foodItems);
        string Separator {  get; set; }
        void AddFoodItem(FoodItemViewModel foodItem);
    }
}
