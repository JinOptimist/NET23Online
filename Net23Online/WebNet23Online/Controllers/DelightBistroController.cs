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
        private const string SEPARATOR=",";

        public DelightBistroController(IFoodItemGenerator foodItemGenerator, IMenuTypeGenerator menuTypeGenerator, WebContext webContext)
        {
            _foodItemGenerator = foodItemGenerator;
            _menuTypeGenerator = menuTypeGenerator;
            _webContext = webContext;
            _foodItemGenerator.Separator=SEPARATOR;
        }

        public IActionResult Index(string menuType)
        {
            FeelDataBase();

            var foodItemsDatas = _webContext.FoodItems.ToList();
            var foodItemVMFromDatas = _foodItemGenerator.GenerateFoodItems(foodItemsDatas);

            //var foodItems = _foodItemGenerator.GenerateFoodItems();
            var viewModel = _menuTypeGenerator.GetMenuTypesFromFoodItems(foodItemVMFromDatas, menuType);
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
            //if (!ModelState.IsValid)
            //{
            //    return View(foodItem);
            //}

            string ingredients = string.Join(SEPARATOR, foodItem.Ingredients);

            var foodItemData = new FoodItemData()
            {
                Name = foodItem.Name,
                Price = foodItem.Price,
                ImgURL = string.IsNullOrEmpty(foodItem.ImgURL) ? null : foodItem.ImgURL,//Пустое значение в FoodItemViewModel
                MenuType = foodItem.MenuType,
                Ingredients = ingredients,
                //Ingredients= foodItem.Ingredients,
                //Ingredients = string.Join(SEPARATOR, foodItem.Ingredients),//Получаем строку из списка
            };

            _webContext.FoodItems.Add(foodItemData);
            _webContext.SaveChanges();

            //_foodItemGenerator.AddFoodItem(foodItem);

            return RedirectToAction(nameof(Index));
        }

        private void FeelDataBase()
        {
            if (!_webContext.FoodItems.Any())
            {
                var foodItems = _foodItemGenerator.GenerateFoodItems();// List FoodItemVM
                foreach (var foodItemVM in foodItems)
                {
                    var foodItemData = new FoodItemData()
                    {
                        Name = foodItemVM.Name,
                        Price = foodItemVM.Price,
                        ImgURL = foodItemVM.ImgURL,
                        MenuType = foodItemVM.MenuType,
                        Ingredients = string.Join(SEPARATOR, foodItemVM.Ingredients),//Получаем строку из списка
                    };
                    _webContext.FoodItems.Add(foodItemData);
                }

                _webContext.SaveChanges();
            }
        }
    }
}
