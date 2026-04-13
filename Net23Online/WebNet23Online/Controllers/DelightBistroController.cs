using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Patterns;
using WebNet23Online.Data;
using WebNet23Online.Data.Models;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class DelightBistroController : Controller
    {
        private IFoodItemGenerator _foodItemGenerator;
        private IMenuTypeGenerator _menuTypeGenerator;
        private WebContext _webContext;
        private const string SEPARATOR = ",";

        public DelightBistroController(IFoodItemGenerator foodItemGenerator, IMenuTypeGenerator menuTypeGenerator, WebContext webContext)
        {
            _foodItemGenerator = foodItemGenerator;
            _menuTypeGenerator = menuTypeGenerator;
            _webContext = webContext;
            _foodItemGenerator.Separator = SEPARATOR;
        }

        public IActionResult Index(string menuType)
        {
            FeelDataBase();

            var foodItemsDatas = _webContext.FoodItems.ToList();
            var foodItemsVM = _foodItemGenerator.GenerateFoodItems(foodItemsDatas);
            var viewModel = _menuTypeGenerator.GetMenuTypesFromFoodItems(foodItemsVM, menuType);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FoodBuilder(int? id)
        {
            if (id.HasValue && id > 0)
            {
                var foodItemData = _webContext.FoodItems
                    .Find(id.Value);

                var changedFoodItemVM = new FoodItemViewModel
                {
                    Id = foodItemData.Id,
                    Name = foodItemData.Name,
                    Price = foodItemData.Price,
                    ImgURL = foodItemData.ImgURL,
                    MenuType = foodItemData.MenuType,
                    Ingredients = foodItemData.Ingredients.Split(SEPARATOR, StringSplitOptions.RemoveEmptyEntries).ToList(),
                };

                return View(changedFoodItemVM);
            }
            var foodItemViewModel = new FoodItemViewModel();
            return View(foodItemViewModel);
        }

        [HttpPost]
        public IActionResult FoodBuilder(FoodItemViewModel foodItem)
        {
            
            // change an existing element
            if (foodItem.Id > 0)
            {
                var changedFoodItemData = _webContext.FoodItems.Find(foodItem.Id);
                var ingredients = string.Join(SEPARATOR, foodItem.Ingredients);
                changedFoodItemData.Name = foodItem.Name;
                changedFoodItemData.Price = foodItem.Price;
                changedFoodItemData.ImgURL = foodItem.ImgURL;
                changedFoodItemData.MenuType = foodItem.MenuType;
                changedFoodItemData.Ingredients = ingredients;
            }
            // create new element
            else
            {
                var newFoodItemDatas = _foodItemGenerator.ConvertVMtoData(foodItem);
                _webContext.FoodItems.Add(newFoodItemDatas);
            }

            _webContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private void FeelDataBase() //Метод в сервис?
        {
            if (!_webContext.FoodItems.Any())
            {
                var foodItems = _foodItemGenerator.GenerateFoodItems();
                foreach (var foodItemVM in foodItems)
                {
                    var foodItemData = _foodItemGenerator.ConvertVMtoData(foodItemVM);
                    _webContext.FoodItems.Add(foodItemData);
                }

                _webContext.SaveChanges();
            }
        }
    }
}
