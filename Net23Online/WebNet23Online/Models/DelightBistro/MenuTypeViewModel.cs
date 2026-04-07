using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Models.DelightBistro
{
    public class MenuTypeViewModel
    {
        public string MenuType { get; set; }
        public string TypeName { get; set; }
        public List<FoodItemViewModel> FoodItems {  get; set; }
    }
}
