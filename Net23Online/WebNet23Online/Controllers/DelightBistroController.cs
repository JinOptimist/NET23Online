using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebNet23Online.Data;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories;
using WebNet23Online.Data.Repositories.Interfaces;
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
        private IMenuRepository _menuRepository;
        private IIngredientsRepository _ingredientsRepository;

        public DelightBistroController(IFoodItemGenerator foodItemGenerator, IMenuTypeGenerator menuTypeGenerator
            , IFoodItemRepository foodItemRepository, IMenuRepository menuRepository, IIngredientsRepository ingredientsRepository, IIngredientGenerator ingredientGenerator)
        {
            _foodItemGenerator = foodItemGenerator;
            _foodItemRepository = foodItemRepository;

            _menuTypeGenerator = menuTypeGenerator;
            _menuRepository = menuRepository;

            _ingredientGenerator = ingredientGenerator;
            _ingredientsRepository = ingredientsRepository;
        }

        public IActionResult Index(string menuType)
        {
            _foodItemGenerator.FeelDataBase();
            _ingredientGenerator.FeelDataBase();
            _menuTypeGenerator.FeelDataBase();

            //var foodItemsDatas = _foodItemRepository.GetAll();
            //var foodItemsVM = _foodItemGenerator.GenerateFoodItemsFromDataBase(foodItemsDatas);
            //var foodItemsVM = _foodItemGenerator.GenerateFoodItemsFromDB(foodItemsDatas);

            //var viewModel = _menuTypeGenerator.GetMenuTypesFromFoodItems(foodItemsVM, menuType);
            var viewModel = _menuTypeGenerator.GetAllMenuViewModel(menuType);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FoodBuilder(int id)
        {
            if (id == 0)
            {
                var foodItemViewModel = new FoodItemViewModel();
                return View(foodItemViewModel);
            }

            var foodItemData = _foodItemRepository.Get(id);
            var changedFoodItemViewModel = _foodItemGenerator.ConvertToFoodItemVM(foodItemData);

            return View(changedFoodItemViewModel);
        }

        [HttpPost]
        public IActionResult FoodBuilder(FoodItemViewModel foodItem)
        {
            // create new element
            if (foodItem.Id == 0)
            {
                //_foodItemGenerator.CreateFoodItemData(foodItem);
                return RedirectToAction(nameof(Index));
            }
            // change element
            var changedFoodItemData = _foodItemRepository.Get(foodItem.Id);
            _foodItemGenerator.ChangeFoodItemData(foodItem, changedFoodItemData);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult CreateMenu()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateMenu(CreateMenuViewModel viewModel)
        {
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
            _ingredientGenerator.CreateIngredientData(viewModel);

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult FoodBuilderData()
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

            var createFoodItemVM = new CreateFoodItemViewModel()
            {
                Menus = menuListItems,
                Ingredients = allIngredientVM
            };

            return View(createFoodItemVM);
        }

        [HttpPost]
        public IActionResult FoodBuilderData(CreateFoodItemViewModel viewModel)
        {
            _foodItemGenerator.CreateFoodItemData(viewModel);

            return RedirectToAction(nameof(Index));
        }

    }
}
