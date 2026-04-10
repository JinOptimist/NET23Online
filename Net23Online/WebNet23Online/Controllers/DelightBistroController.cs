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
            var foodItems = _foodItemGenerator.GenerateFoodItems();
            var viewModel = _menuTypeGenerator.GetMenuTypesFromFoodItems(foodItems, menuType);
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
            return RedirectToAction(nameof(Index));
        }
    }
}
