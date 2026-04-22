using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebNet23Online.Models.DelightBistro
{
    public class CreateFoodItemViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImgURL { get; set; }

        //checkBoxId
        public List<int> SelectedIngredientsId { get; set; }
        public List<CreateIngredientViewModel> Ingredients { get; set; } = new();
        public int? MenuId { get; set; }
        public List<SelectListItem> Menus { get; set; } = new();
    }
}
