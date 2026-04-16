using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebNet23Online.Data.Models
{
    public class FoodItemData:BaseModel
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string MenuType { get; set; } // ??? dont need or ist key?
        public string? ImgURL { get; set; }
        public string Ingredients { get; set; }

        public virtual MenuData? MenuData { get; set; } //null?
        public virtual List<IngredientData> IngredientsList { get; set; } = new();
    }
}
