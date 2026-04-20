using WebNet23Online.Data.Models;
using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Services.Interfaces
{
    public interface IFoodItemGenerator
    {
        //List<FoodItemViewModel> GenerateFoodItems();

        //void AddFoodItem(FoodItemViewModel foodItem);
        void CreateFoodItemData(CreateFoodItemViewModel foodItem);
        void ChangeFoodItemData(CreateFoodItemViewModel foodItem, FoodItemData changedFoodItemData);


        FoodItemViewModel ConvertToFoodItemVM(FoodItemData foodItemData);
        List<FoodItemViewModel> GenerateFoodItemsFromDB(List<FoodItemData> foodItemDatas);
        void FeelDataBase();
        CreateFoodItemViewModel ConvertToCreateFoodItemVM(FoodItemData foodItemData);
    }
}
