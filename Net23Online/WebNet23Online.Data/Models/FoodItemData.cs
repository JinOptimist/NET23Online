using WebNet23Online.Data.DataModels;

namespace WebNet23Online.Data.Models
{
    public class FoodItemData : BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string? ImgURL { get; set; }

        public virtual MenuData? MenuData { get; set; }
        public virtual List<IngredientData> IngredientsList { get; set; } = new();
        // Предпочтительно ли иметь ключ CreatorId?
        public int? CreatorId { get; set; }
        public virtual UserData? Creator { get; set; }
        public virtual ICollection<FoodItemIngredient> FoodItemIngredients { get; set; } = new List<FoodItemIngredient>();

    }
}
