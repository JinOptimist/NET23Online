using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebNet23Online.Data;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories;
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

        public DelightBistroController(IFoodItemGenerator foodItemGenerator, IMenuTypeGenerator menuTypeGenerator
            , IFoodItemRepository foodItemRepository, IMenuRepository menuRepository, IIngredientsRepository ingredientsRepository)
        {
            _foodItemGenerator = foodItemGenerator;
            _menuTypeGenerator = menuTypeGenerator;
            _foodItemRepository = foodItemRepository;
            _menuRepository = menuRepository;
            _ingredientsRepository = ingredientsRepository;
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
            var changedFoodItemViewModel = _foodItemGenerator.ConvertFoodItemToVM(foodItemData);

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
            //var viewModel = new CreateMenuViewModel();
            return View();
        }

        [HttpPost]
        public IActionResult CreateMenu(CreateMenuViewModel viewModel)
        {
            var menuData = new MenuData
            {
                Name = viewModel.Name,
            };

            _menuRepository.Add(menuData);
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
            var ingredientData = new IngredientData
            {
                Name = viewModel.Name,
            };

            _ingredientsRepository.Add(ingredientData);
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

            var createFoodItemVM = new CreateFoodItemViewModel()
            {
                Menus = menuListItems,
            };

            return View(createFoodItemVM);
        }

        [HttpPost]
        public IActionResult FoodBuilderData(CreateFoodItemViewModel viewModel)
        {
            var menuID = viewModel.Menus;

            var foodItemData = new FoodItemData
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                ImgURL = viewModel.ImgURL,
                //IngredientsList = "",
                MenuData = _menuRepository.Get(viewModel.MenuId.Value)

            };

            _foodItemRepository.Add(foodItemData);
            return RedirectToAction(nameof(Index));
        }
        public IActionResult MainIndex(/*string menuType*/)
        {
                       
            var allMenusVM = _menuTypeGenerator.GetAllMenusViewModel();

            return View(allMenusVM);
        }
    }
}
