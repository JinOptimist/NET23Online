using Microsoft.AspNetCore.Mvc;
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

        public DelightBistroController(IFoodItemGenerator foodItemGenerator, IMenuTypeGenerator menuTypeGenerator, WebContext webContext)
        {
            _foodItemGenerator = foodItemGenerator;
            _menuTypeGenerator = menuTypeGenerator;
            _webContext = webContext;
        }

        public IActionResult Index(string menuType)
        {
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
        public IActionResult FoodBuilder(FoodItemViewModel foodItem, string ingredientString = "")
        {
            var foodItemData = new FoodItemData()
            {
                Name = foodItem.Name,
                Price = foodItem.Price,
                ImgURL = foodItem.ImgURL,
                MenuType = foodItem.MenuType,
                Ingredients = ingredientString,
                //Ingredients = string.Join(",", foodItem.Ingredients),//Получаем строку из списка
            };

            _webContext.FoodItems.Add(foodItemData);
            _webContext.SaveChanges();

            //_foodItemGenerator.AddFoodItem(foodItem);

            return RedirectToAction(nameof(Index));
        }

        //public IActionResult FeelDataBase()
        //{

        //    var foodItemsToDB = _foodItemGenerator.GenerateFoodItems();// List FoodItem
        //    foreach (var foodItemVM in foodItemsToDB)
        //    {
        //        var foodItemData = new FoodItemData()
        //        {
        //            Name = foodItemVM.Name,
        //            Price = foodItemVM.Price,
        //            ImgURL = foodItemVM.ImgURL,
        //            MenuType = foodItemVM.MenuType,
        //            Ingredients = string.Join(";", foodItemVM.Ingredients),//Получаем строку из списка
        //        };
        //        _webContext.FoodItems.Add(foodItemData);
        //    }

        //    _webContext.SaveChanges();

        //    return RedirectToAction(nameof(Index));
        //}
    }
}
