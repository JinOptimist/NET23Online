using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.DelightBistro;

namespace WebNet23Online.Controllers
{
    public class DelightBistroController : Controller
    {

        public static List<FoodItemViewModel> _foodItems = GetAllFoodItems();// static menu, delete after add db

        public IActionResult Index(string menuType)
        {
            var allFoods = _foodItems;
            var viewModels = new List<MenuTypeViewModel>
            {
                new MenuTypeViewModel()
                {
                    MenuType="soups",
                    TypeName="Супы",
                    FoodItems =allFoods.Where(x=>x.MenuType=="soups").ToList(),
                },
                new MenuTypeViewModel()
                {
                    MenuType="hot",
                    TypeName="Горячее",

                    FoodItems =allFoods.Where(x=>x.MenuType=="hot").ToList(),
                },
                new MenuTypeViewModel()
                {
                    MenuType="salads",
                    TypeName="Салаты",
                    FoodItems =allFoods.Where(x=>x.MenuType=="salads").ToList(),
                }
            };

            var viewModel = viewModels.Where(x => x.MenuType == menuType).ToList();
            if (string.IsNullOrEmpty(menuType))
            {
                return View(viewModels);
            }
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
            _foodItems.Add(foodItem);
            return RedirectToAction("Index");
        }
        public static List<FoodItemViewModel> GetAllFoodItems()
        {

            return new List<FoodItemViewModel>
             {
                new FoodItemViewModel
                 {
                    Name = "Tom Yum Talay",
                    Price = 20,
                    ImgURL = "/images/delight-bistro/TomYumTalay.jpg",
                    MenuType = "soups",
                    Ingredients = new List<string>
                    {
                        "Креветки",
                        "Шампиньоны",
                        "Лайм",
                        "Паста",
                        "Помидоры",
                        "Перец чили"
                    }
                 },

                new FoodItemViewModel
                {
                    Name = "Lentil Soup",
                    Price = 15,
                    ImgURL = "/images/delight-bistro/LentilSoup.jpg",
                    MenuType = "soups",
                    Ingredients = new List<string>
                   {
                        "Говядина",
                        "Чечевица красная",
                        "Картофель",
                        "Лук репчатый",
                        "Помидоры",
                        "Морковь"
                   }
                },

                new FoodItemViewModel
                {
                    Name = "Стейк с пастой",
                    Price = 30,
                    ImgURL = "/images/delight-bistro/Steak2.jpg",
                    MenuType = "hot",
                    Ingredients = new List<string>
                    {
                        "Говяжий стейк",
                        "Паста",
                        "Сливочно‑перечный соус",
                        "Зелень"
                    }
                },

                new FoodItemViewModel
                {
                    Name = "Лазанья",
                    Price = 30,
                    ImgURL = "/images/delight-bistro/Lasana.jpg",
                    MenuType = "hot",
                    Ingredients = new List<string>
                    {
                        "Паста Лазанья",
                        "Фарш говяжий",
                        "Соус бешамель",
                        "Сыр пармезан",
                        "Помидоры",
                        "Зелень"
                    }
                },

                new FoodItemViewModel
                {
                    Name = "Хрустящая курица с кунжутом",
                    Price = 25,
                    ImgURL = "/images/delight-bistro/CrispySesameChicken.jpg",
                    MenuType = "hot",
                    Ingredients = new List<string>
                    {
                        "Курица",
                        "Семена кунжута",
                        "Мёд",
                        "Рис",
                        "Лук репчатый",
                        "Чесночная паста",
                        "Белый перец"
                    }
                },

                new FoodItemViewModel
                {
                    Name = "Паста с креветками, чесноком и чили",
                    Price = 25,
                    ImgURL = "/images/delight-bistro/ChilliGarlicPrawnPasta.jpg",
                    MenuType = "hot",
                    Ingredients = new List<string>
                    {
                        "Креветки",
                        "Лингвини",
                        "Помидоры черри",
                        "Хлопья чили",
                        "Зелень"
                    }
                },

                new FoodItemViewModel
                {
                    Name = "Салат Цезарь",
                    Price = 20,
                    ImgURL = "/images/delight-bistro/CesarSalad.jpg",
                    MenuType = "salads",
                    Ingredients = new List<string>
                    {
                        "Римский салат",
                        "Сухарики",
                        "Пармезан",
                        "Чёрный молотый перец",
                        "Курица",
                        "Морковь"
                    }
                },

                new FoodItemViewModel
                {
                    Name = "Салат средиземноморский",
                    Price = 25,
                    ImgURL = "/images/delight-bistro/Salad2.jpg",
                    MenuType = "salads",
                    Ingredients = new List<string>
                    {
                        "Микс салатов",
                        "Помидоры черри",
                        "Чёрные оливки",
                        "Сыр",
                        "Чёрный молотый перец",
                        "Оливковое масло"
                    }
                }
            };
        }//static method
    }
}
