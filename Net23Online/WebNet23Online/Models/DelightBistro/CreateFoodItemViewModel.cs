using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebNet23Online.Models.DelightBistro
{
    public class CreateFoodItemViewModel
    {
        // Тут минимальное количество данных
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImgURL { get; set; }

        // Свойства для связзи в базы данных
        public List<int> SelectedIngredientsId {  get; set; }
        public List<CreateIngredientViewModel> Ingredients { get; set; }

        public int? MenuId { get; set; } // длЯ связи в бд. одно меню на разные FI 
        public List<SelectListItem> Menus { get; set; } = new(); //Выпадающий список для выбора одного меню для FI
    }
}
