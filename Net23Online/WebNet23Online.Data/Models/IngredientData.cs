using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models
{
    public class IngredientData : BaseModel
    {
        public string Name { get; set; }

        public virtual List<FoodItemData> FoodItems { get; set; } = new();
        public int? CreatorId { get; set; }
        public virtual UserData? Creator { get; set; }
    }
}
