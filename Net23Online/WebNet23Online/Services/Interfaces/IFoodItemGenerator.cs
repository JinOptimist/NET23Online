using WebNet23Online.Data.Models;
using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Services.Interfaces
{
    public interface IFoodItemGenerator
    {
        
        void CreateFoodItemData(CreateFoodItemViewModel foodItem);
        void ChangeFoodItemData(CreateFoodItemViewModel foodItem, FoodItemData changedFoodItemData);

        FoodItemViewModel ConvertToFoodItemVM(FoodItemData foodItemData);
        void FeelDataBase();
        CreateFoodItemViewModel ConvertToCreateFoodItemVM(FoodItemData foodItemData);
    }
}
