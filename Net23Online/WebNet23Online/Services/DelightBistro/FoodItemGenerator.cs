using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.IdentityModel.Tokens;
using WebNet23Online.Data.Models;
using WebNet23Online.Data.Repositories;
using WebNet23Online.Data.Repositories.Interfaces;
using WebNet23Online.Models.DelightBistro;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Services.DelightBistro
{
    public class FoodItemGenerator : IFoodItemGenerator
    {
        private List<FoodItemViewModel> _foodItems;
        private const string SEPARATOR = ",";
        private IFoodItemRepository _foodItemRepository;
        private IMenuRepository _menuRepository;
        private IIngredientsRepository _ingredientsRepository;
        public FoodItemGenerator(IFoodItemRepository foodItemRepository, IMenuRepository menuRepository, IIngredientsRepository ingredientsRepository)
        {
            _foodItemRepository = foodItemRepository;
            _menuRepository = menuRepository;
            _ingredientsRepository = ingredientsRepository;

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


        public void CreateFoodItemData(CreateFoodItemViewModel viewModel)
        {
            //var menuID = viewModel.Menus;
            var selectedIngredients = new List<IngredientData>();
            if (!viewModel.SelectedIngredientsId.IsNullOrEmpty())
            {
                selectedIngredients = _ingredientsRepository.GetAll()
                    .Where(x => viewModel.SelectedIngredientsId.Contains(x.Id)).ToList();
            }
            MenuData menuData = null;
            if (viewModel.MenuId != null)
            {
                menuData = _menuRepository.Get(viewModel.MenuId.Value);
            }
            var newFoodItemData = new FoodItemData()
            {
                Name = viewModel.Name,
                Price = viewModel.Price,
                ImgURL = viewModel.ImgURL,

                MenuData = /*_menuRepository.Get(viewModel.MenuId.Value)*/menuData,
                IngredientsList = selectedIngredients
            };

            _foodItemRepository.Add(newFoodItemData);
        }

        public void ChangeFoodItemData(CreateFoodItemViewModel foodItem, FoodItemData changedFoodItemData)
        {

            if (changedFoodItemData != null)
            {
                changedFoodItemData.Name = foodItem.Name;
                changedFoodItemData.Price = foodItem.Price;
                changedFoodItemData.ImgURL = foodItem.ImgURL;

                _foodItemRepository.UpdateData(changedFoodItemData);
            }

        }

        public FoodItemViewModel ConvertToFoodItemVM(FoodItemData foodItemData)
        {
            var foodItemViewModel = new FoodItemViewModel
            {
                Id = foodItemData.Id,
                Name = foodItemData.Name,
                Price = foodItemData.Price,
                ImgURL = foodItemData.ImgURL,
                MenuType = foodItemData.MenuData?.Name ?? "Общее меню",

                Ingredients = (foodItemData.IngredientsList ?? new List<IngredientData>())
                .Select(fi => fi.Name).ToList()
            };

            return foodItemViewModel;
        }

        public void FeelDataBase()
        {
            if (_foodItemRepository.Any())
            {
                return;
            }

            var foodItems = _foodItems;
            foreach (var foodItemVM in foodItems)
            {
                //CreateFoodItemData(foodItemVM);
            }
        }

        //delete
        public List<FoodItemViewModel> GenerateFoodItemsFromDB(List<FoodItemData> foodItemDatas)
        {
            var foodItemsViewModels = foodItemDatas.Select(x => new FoodItemViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Price = x.Price,
                ImgURL = x.ImgURL,
                MenuType = x.MenuData?.Name ?? "Общее меню",

                Ingredients = (x.IngredientsList ?? new List<IngredientData>())
                .Select(fi => fi.Name).ToList()

            });
            return foodItemsViewModels.ToList();
        }





    }
}
