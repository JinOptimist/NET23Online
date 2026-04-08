using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class MenuTypeGenerator : IMenuTypeGenerator
    {

        public List<MenuTypeViewModel> GetMenuTypesFromFoodItems(List<FoodItemViewModel> foodItems, string sortMenuType)
        {

            var allMenuTypes = new List<MenuTypeViewModel>
            {
                new MenuTypeViewModel()
                {
                    MenuType = "soups",
                    TypeName = "Супы",
                    FoodItems = foodItems.Where(x => x.MenuType=="soups").ToList(),
                },
                new MenuTypeViewModel()
                {
                    MenuType = "hot",
                    TypeName = "Горячее",

                 FoodItems = foodItems.Where(x => x.MenuType=="hot").ToList(),
                },
                new MenuTypeViewModel()
                {
                    MenuType = "salads",
                    TypeName = "Салаты",
                    FoodItems = foodItems.Where(x => x.MenuType=="salads").ToList(),
                }
            };

            var OneMenuType = allMenuTypes.Where(x => x.MenuType == sortMenuType).ToList();
            if (string.IsNullOrEmpty(sortMenuType))
            {
                return allMenuTypes;
            }
            return OneMenuType;
        }

    }
}
