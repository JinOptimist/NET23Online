using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services;
using WebNet23Online.Services.Interfaces;


namespace WebNet23Online.Controllers
{
    public class DelightBistroController : Controller
    {
        private IFoodItemGenerator _foodItemGenerator;
        private IMenuTypeGenerator _menuTypeGenerator;

        private IFoodItemRepository _foodItemRepository;
        private IMenuRepository _menuRepository; //MenuTypeData
        private IIngredientsRepository _ingredientsRepository; //IngredientData

        public DelightBistroController(IFoodItemGenerator foodItemGenerator, IMenuTypeGenerator menuTypeGenerator, IFoodItemRepository foodItemRepository)
        {
            _foodItemGenerator = foodItemGenerator;
            _menuTypeGenerator = menuTypeGenerator;
            _foodItemRepository = foodItemRepository;
        }

        public IActionResult Index(string menuType)
        {
            _foodItemGenerator.FeelDataBase();

            var foodItemsDatas = _foodItemRepository.GetAll();
            var foodItemsVM = _foodItemGenerator.GenerateFoodItems(foodItemsDatas);
            var viewModel = _menuTypeGenerator.GetMenuTypesFromFoodItems(foodItemsVM, menuType);

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
            var changedFoodItemViewModel = _foodItemGenerator.ConvertDataToVM(foodItemData);

            return View(changedFoodItemViewModel);
        }

        [HttpPost]
        public IActionResult FoodBuilder(FoodItemViewModel foodItem)
        {
            // create new element
            if (foodItem.Id == 0)
            {
                _foodItemGenerator.CreateOrChangeFoodItemData(foodItem);
                return RedirectToAction(nameof(Index));
            }
            // change element
            var changedFoodItemData = _foodItemRepository.Get(foodItem.Id);
            _foodItemGenerator.CreateOrChangeFoodItemData(foodItem, changedFoodItemData);

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
            //var viewModel2=new MenuTypeViewModel();

            return RedirectToAction(nameof(Index));
        }

    }
}
