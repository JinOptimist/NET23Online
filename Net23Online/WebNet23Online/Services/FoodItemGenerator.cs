using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services
{
    public class FoodItemGenerator : IFoodItemGenerator
    {
        private List<FoodItemViewModel> _foodItems;
        private const string SEPARATOR=",";
        private IFoodItemRepository _foodItemRepository;
        public FoodItemGenerator(IFoodItemRepository foodItemRepository)
        {
            _foodItemRepository = foodItemRepository;

            //DataBase Is Empty
            _foodItems = new List<FoodItemViewModel>
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
        }

        public void AddFoodItem(FoodItemViewModel foodItem)
        {
            _foodItems.Add(foodItem);
        }

        public List<FoodItemViewModel> GenerateFoodItems()
        {
            return _foodItems;
        }
        public List<FoodItemViewModel> GenerateFoodItems(List<FoodItemData> foodItemDatas)
        {
            var foodItemsViewModels = foodItemDatas.Select(x => new FoodItemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImgURL = x.ImgURL,
                MenuType = x.MenuType,

                Ingredients = x.Ingredients.Split(SEPARATOR
                , StringSplitOptions.RemoveEmptyEntries).ToList(),
            });
            return foodItemsViewModels.ToList();
        }

        public void CreateOrChangeFoodItemData(FoodItemViewModel foodItem, FoodItemData changedFoodItemData = null)
        {
            string ingredients = string.Join(SEPARATOR, foodItem.Ingredients);

            if (changedFoodItemData != null)
            {
                changedFoodItemData.Name = foodItem.Name;
                changedFoodItemData.Price = foodItem.Price;
                changedFoodItemData.ImgURL = foodItem.ImgURL;
                changedFoodItemData.MenuType = foodItem.MenuType;
                changedFoodItemData.Ingredients = ingredients;
                _foodItemRepository.SaveChanges();
            }
            else
            {
                var newFoodItemData = new FoodItemData()
                {
                    Id = foodItem.Id,
                    Name = foodItem.Name,
                    Price = foodItem.Price,
                    ImgURL = foodItem.ImgURL,
                    MenuType = foodItem.MenuType,
                    Ingredients = ingredients,
                };
                _foodItemRepository.Add(newFoodItemData);
            }
        }

        public FoodItemViewModel ConvertDataToVM(FoodItemData foodItemData)
        {
            var foodItemViewModel = new FoodItemViewModel
            {
                Id = foodItemData.Id,
                Name = foodItemData.Name,
                Price = foodItemData.Price,
                ImgURL = foodItemData.ImgURL,
                MenuType = foodItemData.MenuType,
                Ingredients = foodItemData.Ingredients.Split(SEPARATOR,
                    StringSplitOptions.RemoveEmptyEntries).ToList(),
            };

            return foodItemViewModel;
        }

        public void FeelDataBase()
        {
            if (!_foodItemRepository.Any())
            {
                var foodItems = GenerateFoodItems();
                foreach (var foodItemVM in foodItems)
                {
                    CreateOrChangeFoodItemData(foodItemVM);
                }
            }
        }

    }
}
