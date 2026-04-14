using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Data;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services.Interfaces;
using WebNet23Online.Data.Repositories.Interfaces;


namespace WebNet23Online.Controllers
{
    public class DelightBistroController : Controller
    {
        private IFoodItemGenerator _foodItemGenerator;
        private IMenuTypeGenerator _menuTypeGenerator;

        private IFoodItemRepository _foodItemRepository;// Хотим ли мы создавать свойство репозиторя в сервисе?
        //private WebContext _webContext; //delete after add repository

        private const string SEPARATOR = ",";// как связать это поле с полем _foodItemGenerator

        public DelightBistroController(IFoodItemGenerator foodItemGenerator, IMenuTypeGenerator menuTypeGenerator, /*WebContext webContext*/ /*delete*//*,*/ IFoodItemRepository foodItemRepository)
        {
            _foodItemGenerator = foodItemGenerator;
            _menuTypeGenerator = menuTypeGenerator;
            //_webContext = webContext;//delete
            _foodItemGenerator.Separator = SEPARATOR;
            _foodItemRepository = foodItemRepository;
        }

        public IActionResult Index(string menuType)
        {
            FeelDataBase();

            var foodItemsDatas = _foodItemRepository.GetAll();//List FIDatas
            var foodItemsVM = _foodItemGenerator.GenerateFoodItems(foodItemsDatas);
            var viewModel = _menuTypeGenerator.GetMenuTypesFromFoodItems(foodItemsVM, menuType);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult FoodBuilder(int id)
        {
            if (/*id.HasValue &&*/ id > 0)
            {
                //var foodItemData = _webContext.FoodItems
                //    .FirstOrDefault(x => x.Id == id); //delete
                var foodItemData = _foodItemRepository.Get(id);
                //ChangeFoodItemData();
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
            //Переписать if else=> сразу негативный сценарий
            // change an existing element
            if (foodItem.Id > 0)
            {
                //Convert methode
                var changedFoodItemData = _foodItemRepository.Get(foodItem.Id);
                _foodItemGenerator.ChangeFoodItemData(foodItem, changedFoodItemData);

                ////var convertVMtoData = _foodItemGenerator.ConvertVMtoData(foodItem);
                //var ingredients = string.Join(SEPARATOR, foodItem.Ingredients);

                //changedFoodItemData.Name = foodItem.Name;
                //changedFoodItemData.Price = foodItem.Price;
                //changedFoodItemData.ImgURL = foodItem.ImgURL;
                //changedFoodItemData.MenuType = foodItem.MenuType;
                //changedFoodItemData.Ingredients = ingredients;
            }
            // create new element
            else
            {
                _foodItemGenerator.ChangeFoodItemData(foodItem);
                //var newFoodItemDatas = _foodItemGenerator.ConvertVMtoData(foodItem);
                //_foodItemRepository.Add(newFoodItemDatas);
            }

            //_webContext.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

        private void FeelDataBase() //Метод в сервис?
        {
            if (!_foodItemRepository.Any())
            {
                var foodItems = _foodItemGenerator.GenerateFoodItems();
                foreach (var foodItemVM in foodItems)
                {
                    var foodItemData = _foodItemGenerator.ConvertVMtoData(foodItemVM);
                    _foodItemRepository.Add(foodItemData);
                }

                //_webContext.SaveChanges();
            }
        }
    }
}
