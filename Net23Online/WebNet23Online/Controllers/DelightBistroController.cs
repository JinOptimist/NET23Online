using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebNet23Online.Data;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories;
using WebNet23Online.Data.Repositories.Interfaces.DelightBistro;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services;
using WebNet23Online.Services.DelightBistro;
using WebNet23Online.Services.Interfaces;


namespace WebNet23Online.Controllers
{
    public class DelightBistroController : Controller
    {
        private IFoodItemGenerator _foodItemGenerator;
        private IMenuTypeGenerator _menuTypeGenerator;
        private IIngredientGenerator _ingredientGenerator;

        private IFoodItemRepository _foodItemRepository;


        public DelightBistroController(IFoodItemGenerator foodItemGenerator, IMenuTypeGenerator menuTypeGenerator
            , IFoodItemRepository foodItemRepository, IMenuRepository menuRepository, IIngredientsRepository ingredientsRepository, IIngredientGenerator ingredientGenerator)
        {
            _foodItemGenerator = foodItemGenerator;
            _foodItemRepository = foodItemRepository;

            _menuTypeGenerator = menuTypeGenerator;

            _ingredientGenerator = ingredientGenerator;

        }

        public IActionResult Index(string menuType)
        {
            _foodItemGenerator.FeelDataBase();
            _ingredientGenerator.FeelDataBase();
            _menuTypeGenerator.FeelDataBase();

            var viewModel = _menuTypeGenerator.GetAllMenuViewModel(menuType);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult CreateMenu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMenu(CreateMenuViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            _menuTypeGenerator.CreateMenuData(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateIngredient()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateIngredient(CreateIngredientViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }

            _ingredientGenerator.CreateIngredientData(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult FoodBuilderData(int id)
        {
            if (id > 0)
            {
                var changedFoodItemData = _foodItemRepository.Get(id);

                var viewModel = _foodItemGenerator.ConvertToCreateFoodItemVM(changedFoodItemData);
                return View(viewModel);

            }
            var createFoodItemVM = _foodItemGenerator.ConvertToCreateFoodItemVM();

            return View(createFoodItemVM);
        }

        [HttpPost]
        public IActionResult FoodBuilderData(CreateFoodItemViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                viewModel.Menus= _foodItemGenerator.SelectMenu();
                viewModel.Ingredients = _foodItemGenerator.ChekBoxIngredients();
                return View(viewModel);
            }

            if (viewModel.Id == 0)
            {
                _foodItemGenerator.CreateFoodItemData(viewModel);
                return RedirectToAction(nameof(Index));
            }
            _foodItemGenerator.ChangeFoodItemData(viewModel);

            return RedirectToAction(nameof(AllFoodItems));
        }

        public IActionResult AllFoodItems()
        {

            var foodItemsData = _foodItemRepository.GetAllIncludeMenuAndIngredients();
            var viewModel = foodItemsData.Select(_foodItemGenerator.ConvertToFoodItemVM).ToList();

            return View(viewModel);
        }


    }
}
