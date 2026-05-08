
using WebNet23Online.Data.Models;

namespace WebNet23Online.Data.DataModels
{
    public class FoodItemIngredient : BaseModel
    {
        public int FoodItemId { get; set; }
        public int IngredientId {  get; set; }
        public int QuantityInGrams { get; set; } // Количество ингредиента в FoodItem

        public virtual FoodItemData FoodItem { get; set; }
        public virtual IngredientData Ingredient { get; set; }
    }
}

