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
        private IIngredientGenerator _ingredientGenerator;
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

                MenuData = menuData,
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

        public CreateFoodItemViewModel ConvertToCreateFoodItemVM(FoodItemData foodItemData)
        {
            var allIngredientsDatas = _ingredientsRepository.GetAll();
            var allIngredientVM = _ingredientGenerator.GenerateIngredients(allIngredientsDatas);
            var selectMenu = _menuRepository.GetAll();
            var menuListItems = new List<SelectListItem>();
            menuListItems.AddRange(selectMenu.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }));

            var viewModel = new CreateFoodItemViewModel
            {
                Id = foodItemData.Id,
                Name = foodItemData.Name,
                Price = foodItemData.Price,
                ImgURL = foodItemData.ImgURL ?? string.Empty,

                MenuId = foodItemData.MenuData?.Id,
                SelectedIngredientsId = foodItemData.IngredientsList
                .Select(x => x.Id).ToList(),

                Ingredients = allIngredientVM,
                Menus = menuListItems
            };

            return viewModel;
        }
        public void FeelDataBase()
        {
            if (_foodItemRepository.Any())
            {
                return;
            }

            var foodItems = _foodItems;
            var foodItemData = new FoodItemData
            {
                Name ="Вода",
                Price = 5
            };
            _foodItemRepository.Add(foodItemData);
        }
    }
}
