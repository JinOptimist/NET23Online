using WebNet23Online.Data.Models;
using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Services.Interfaces
{
    public interface IFoodItemGenerator
    {
        List<FoodItemViewModel> GenerateFoodItems();
        List<FoodItemViewModel> GenerateFoodItems(List<FoodItemData> foodItems);
        void AddFoodItem(FoodItemViewModel foodItem);
        //void CreateOrChangeFoodItemData(FoodItemViewModel foodItem,
        //    FoodItemData changedFoodItemData = null);
        void CreateFoodItemData(FoodItemViewModel foodItem);
        void ChangeFoodItemData(FoodItemViewModel foodItem, FoodItemData changedFoodItemData);


        FoodItemViewModel ConvertFoodItemToVM(FoodItemData foodItemData);
        List<FoodItemViewModel> GenerateFoodItemsFromDB(List<FoodItemData> foodItemDatas);
        void FeelDataBase();
    }
}
