using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Services.Interfaces
{
    public interface IMenuTypeGenerator
    {
        //sortMenuType - это параметр из экшена
        List<MenuTypeViewModel> GetMenuTypesFromFoodItems(List<FoodItemViewModel> foodItems/*, string sortMenuType*/);
    }
}