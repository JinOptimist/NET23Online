using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using WebNet23Online.Data.Enums;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces.DelightBistro;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services.DelightBistro
{
    public class FoodItemGenerator : IFoodItemGenerator
    {
        private IFoodItemRepository _foodItemRepository;
        private IMenuRepository _menuRepository;
        private IIngredientsRepository _ingredientsRepository;
        private IIngredientGenerator _ingredientGenerator;
        private IAuthService _authService;
        private IWebHostEnvironment _webHostEnvironment;

        public FoodItemGenerator(IFoodItemRepository foodItemRepository, IMenuRepository menuRepository,
            IIngredientsRepository ingredientsRepository, IIngredientGenerator ingredientGenerator,
            IAuthService authService, IWebHostEnvironment webHostEnvironment)
        {
            _foodItemRepository = foodItemRepository;
            _menuRepository = menuRepository;
            _ingredientsRepository = ingredientsRepository;
            _ingredientGenerator = ingredientGenerator;
            _authService = authService;
            _webHostEnvironment = webHostEnvironment;
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

        public void CreateFoodItemData(CreateFoodItemViewModel viewModel)
        {


            var newFoodItemData = new FoodItemData()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                ImgURL = viewModel.ImgURL,

                MenuData = selectedMenu,
                IngredientsList = selectedIngredients,
                Creator = _authService.GetUser()
            };

            _foodItemRepository.Add(newFoodItemData);

            GetImgFile(viewModel, newFoodItemData);

        }

        public void ChangeFoodItemData(CreateFoodItemViewModel viewModel)
        {
            var selectedIngredients = GetSelectedIngredients(viewModel);
            var selectedMenu = GetSelectedMenu(viewModel);
