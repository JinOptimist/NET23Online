using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class DelightBistroController : Controller
    {
        private IFoodItemGenerator _foodItemGenerator;
        private IMenuTypeGenerator _menuTypeGenerator;
        public DelightBistroController(IFoodItemGenerator foodItemGenerator, IMenuTypeGenerator menuTypeGenerator)
        {
            _foodItemGenerator = foodItemGenerator;
            _menuTypeGenerator = menuTypeGenerator;
        }

        public IActionResult Index(string menuType)
        {
            // Сервисы не завязывать на данных из экшенов?
            var viewModels = _menuTypeGenerator.GetMenuTypesFromFoodItems(_foodItemGenerator.GenerateFoodItems()/*,menuType*/);

            // Если сервис связать с параметром menuType, то в экшене требуется эта логика
            if (string.IsNullOrEmpty(menuType))
            {
                return View(viewModels);
            }

            var viewModel = viewModels.Where(x => x.MenuType == menuType).ToList();

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FoodBuilder()
        {
            return View();
        }

        [HttpPost]
        public IActionResult FoodBuilder(FoodItemViewModel foodItem)
        {
            _foodItemGenerator.AddFoodItem(foodItem);
            return RedirectToAction("Index");
        }
    }
}
