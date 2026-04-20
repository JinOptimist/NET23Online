using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services.DelightBistro
{
    public class MenuTypeGenerator : IMenuTypeGenerator
    {
        private IMenuRepository _menuRepository;
        private IFoodItemGenerator _foodItemGenerator;
        private List<CreateMenuViewModel> _menus;
        private const string SEPARATOR = ",";


        public MenuTypeGenerator(IMenuRepository menuRepository, IFoodItemGenerator foodItemGenerator)
        {
            _menuRepository = menuRepository;
            _foodItemGenerator = foodItemGenerator;
        }

        public void FeelDataBase()
        {

            if (_menuRepository.Any())
            {
                return;
            }

            var menus = "soups, hot, salads";

            _menus = menus.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries)
                .Select(x => new CreateMenuViewModel
                {
                    Name = x.Trim()
                }).ToList();

            var menusVM = _menus;
            foreach (var menu in menusVM)
            {
                CreateMenuData(menu);
            }
        }

        public void CreateMenuData(CreateMenuViewModel viewModel)
        {
            var menuData = new MenuData
            {
                Name = viewModel.Name,
            };

            _menuRepository.Add(menuData);
        }

        //public List<MenuTypeViewModel> GetMenuTypesFromFoodItems(List<FoodItemViewModel> foodItems, string sortMenuType)
        //{

        //    var allMenuTypes = new List<MenuTypeViewModel>
        //    {
        //        new MenuTypeViewModel()
        //        {
        //            Name = "soups",
        //            FoodItems = foodItems.Where(x => x.MenuType=="soups").ToList(),
        //        },
        //        new MenuTypeViewModel()
        //        {
        //            Name = "hot",

        //         FoodItems = foodItems.Where(x => x.MenuType=="hot").ToList(),
        //        },
        //        new MenuTypeViewModel()
        //        {
        //            Name = "salads",
        //            FoodItems = foodItems.Where(x => x.MenuType=="salads").ToList(), //change x => x.MenuType=="salads"
        //        }
        //    };

        //    var OneMenuType = allMenuTypes.Where(x => x.Name == sortMenuType).ToList();
        //    if (string.IsNullOrEmpty(sortMenuType))
        //    {
        //        return allMenuTypes;
        //    }
        //    return OneMenuType;
        //}

        public MenuTypeViewModel ConvertMenuDataToViewModel(MenuData menuData)
        {

            return new MenuTypeViewModel
            {
                Id = menuData.Id,
                Name = menuData.Name,
                FoodItems = (menuData.FoodItems ?? new List<FoodItemData>())
                    .Select(_foodItemGenerator.ConvertToFoodItemVM)
                    .ToList()
            };
        }

        public List<MenuTypeViewModel> GetAllMenuViewModel(string sortName)
        {
            var menuListDatas = _menuRepository.GetAllIncludeFoodItemsWithIngredients(sortName);
            var menuVMList = menuListDatas.Select(ConvertMenuDataToViewModel).ToList();

            return menuVMList;
        }


    }
}
