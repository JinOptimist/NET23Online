using WebNet23Online.Data.Models;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Models.DelightBistro
{
    public class AllFoodItemWithPermissionViewModel
    {
        public List<FoodItemViewModel> FoodItems { get; set; }
        public bool IsAdmin { get; set; }
    }
}
