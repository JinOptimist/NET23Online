using WebNet23Online.Data.Models;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Models.DelightBistro
{
    public class MenuTypeViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<FoodItemViewModel> FoodItems { get; set; }
        public string? CreatorName { get; set; }

    }
}
