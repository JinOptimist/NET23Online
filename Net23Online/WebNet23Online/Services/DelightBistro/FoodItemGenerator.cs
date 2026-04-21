using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services.Interfaces;
using static System.Net.WebRequestMethods;

namespace WebNet23Online.Services.DelightBistro
{
    public class FoodItemGenerator : IFoodItemGenerator
    {
        private IFoodItemRepository _foodItemRepository;
        private IMenuRepository _menuRepository;
        private IIngredientsRepository _ingredientsRepository;
        private IIngredientGenerator _ingredientGenerator;
        public FoodItemGenerator(IFoodItemRepository foodItemRepository, IMenuRepository menuRepository, IIngredientsRepository ingredientsRepository, IIngredientGenerator ingredientGenerator)
        {
            _foodItemRepository = foodItemRepository;
            _menuRepository = menuRepository;
            _ingredientsRepository = ingredientsRepository;
            _ingredientGenerator = ingredientGenerator;
        }

        public void CreateFoodItemData(CreateFoodItemViewModel viewModel)
        {
            var selectedIngredients = new List<IngredientData>();
            if (!viewModel.SelectedIngredientsId.IsNullOrEmpty())
            {
                selectedIngredients = _ingredientsRepository.GetAll()
                    .Where(x => viewModel.SelectedIngredientsId.Contains(x.Id)).ToList();
            }

            MenuData menuData = null;
            if (viewModel.MenuId != null)
            {
                menuData = _menuRepository.Get(viewModel.MenuId.Value);
            }
            var newFoodItemData = new FoodItemData()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                ImgURL = viewModel.ImgURL,

                MenuData = menuData,
                IngredientsList = selectedIngredients
            };

            _foodItemRepository.Add(newFoodItemData);
        }

        public void ChangeFoodItemData(CreateFoodItemViewModel viewModel)
        {

            var selectedIngredients = new List<IngredientData>();
            if (!viewModel.SelectedIngredientsId.IsNullOrEmpty())
            {
                selectedIngredients = _ingredientsRepository.GetAll()
                    .Where(x => viewModel.SelectedIngredientsId.Contains(x.Id)).ToList();
            }
            MenuData menuData = null;
            if (viewModel.MenuId != null)
            {
                menuData = _menuRepository.Get(viewModel.MenuId.Value);
            }

            var changedFoodItemData = _foodItemRepository.Get(viewModel.Id);
            changedFoodItemData.IngredientsList.Clear();

            changedFoodItemData.Name = viewModel.Name;
            changedFoodItemData.Price = viewModel.Price;
            changedFoodItemData.ImgURL = viewModel.ImgURL;
            changedFoodItemData.MenuData = menuData;
            changedFoodItemData.IngredientsList = selectedIngredients;

            _foodItemRepository.Update(changedFoodItemData);
        }

        public FoodItemViewModel ConvertToFoodItemVM(FoodItemData foodItemData)
        {
            var foodItemViewModel = new FoodItemViewModel
            {
                Id = foodItemData.Id,
                Name = foodItemData.Name,
                Price = foodItemData.Price,
                ImgURL = foodItemData.ImgURL,
                MenuType = foodItemData.MenuData?.Name ?? "Общее меню",
                Ingredients = foodItemData.IngredientsList
                .Select(fi => fi.Name).ToList()

            };

            return foodItemViewModel;
        }

        public CreateFoodItemViewModel ConvertToCreateFoodItemVM(FoodItemData foodItemData = null)
        {
            var selectMenu = _menuRepository.GetAll();
            var menuListItems = new List<SelectListItem>();
            menuListItems.AddRange(selectMenu.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }));

            var allIngredientsDatas = _ingredientsRepository.GetAll();
            var allIngredientVM = _ingredientGenerator.GenerateIngredients(allIngredientsDatas);

            if (foodItemData == null)
            {
                var createFoodItemVM = new CreateFoodItemViewModel()
                {
                    Menus = menuListItems,
                    Ingredients = allIngredientVM
                };

                return createFoodItemVM;
            }

            var viewModel = new CreateFoodItemViewModel
            {
                Id = foodItemData.Id,
                Name = foodItemData.Name,
                Price = foodItemData.Price,
                ImgURL = foodItemData.ImgURL,

                MenuId = foodItemData.MenuData?.Id,
                SelectedIngredientsId = foodItemData.IngredientsList
                .Select(x => x.Id).ToList(),

                Ingredients = allIngredientVM,
                Menus = menuListItems
            };

            return viewModel;
        }
        public void FeelDataBase()
        {
            if (_foodItemRepository.Any())
            {
                return;
            }

            var foodItemData = new FoodItemData
            {
                Name = "Вода",
                Price = 5,
                ImgURL = "https://png.klev.club/uploads/posts/2024-03/png-klev-club-p-stakan-vodi-png-9.png",

            };
            _foodItemRepository.Add(foodItemData);
        }
    }
}
