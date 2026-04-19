using WebNet23Online.Data.Models;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Models.DelightBistro
{
    public class MenuTypeViewModel : BaseModel
    {
        public string Name { get; set; }
        public List<FoodItemViewModel> FoodItems { get; set; }
    }
}
