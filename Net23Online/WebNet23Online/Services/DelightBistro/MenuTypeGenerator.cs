using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services.DelightBistro
{
    public class MenuTypeGenerator : IMenuTypeGenerator
    {
        private IMenuRepository _menuRepository;
        private IFoodItemGenerator _foodItemGenerator;

        public MenuTypeGenerator(IMenuRepository menuRepository, IFoodItemGenerator foodItemGenerator)
        {
            _menuRepository = menuRepository;
            _foodItemGenerator = foodItemGenerator;
        }

        public List<MenuTypeViewModel> GetMenuTypesFromFoodItems(List<FoodItemViewModel> foodItems, string sortMenuType)
        {

            var allMenuTypes = new List<MenuTypeViewModel>
            {
                new MenuTypeViewModel()
                {
                    Name = "soups",
                    FoodItems = foodItems.Where(x => x.MenuType=="soups").ToList(),
                },
                new MenuTypeViewModel()
                {
                    Name = "hot",

                 FoodItems = foodItems.Where(x => x.MenuType=="hot").ToList(),
                },
                new MenuTypeViewModel()
                {
                    Name = "salads",
                    FoodItems = foodItems.Where(x => x.MenuType=="salads").ToList(), //change x => x.MenuType=="salads"
                }
            };

            var OneMenuType = allMenuTypes.Where(x => x.Name == sortMenuType).ToList();
            if (string.IsNullOrEmpty(sortMenuType))
            {
                return allMenuTypes;
            }
            return OneMenuType;
        }
        //delete
        //public List<MenuTypeViewModel> GetMenuFromData()
        //{
        //    var menus = _menuRepository.GetAll();
        //    var menuVM = menus.Select(x => new MenuTypeViewModel
        //    {
        //        Name = x.Name,
        //    });

        //    return menuVM.ToList();
        //}

        public MenuTypeViewModel ConvertMenuDataToViewModel(MenuData menuData)
        {

            return new MenuTypeViewModel
            {
                Id = menuData.Id,
                Name = menuData.Name,
                FoodItems = (menuData.FoodItems ?? new List<FoodItemData>())
                    .Select(_foodItemGenerator.ConvertFoodItemToVM)
                    .ToList()
            };

        }
        public List<MenuTypeViewModel> GetAllMenusIncludesFoodItemAndIngredientsViewModel(string sortName)
        {
            var menuListDatas = _menuRepository.GetAllIncludeFoodItemsWithIngredients(sortName);
            var menuVMList = menuListDatas.Select(ConvertMenuDataToViewModel).ToList();

            return menuVMList;
        }

    }
}
