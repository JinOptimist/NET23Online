using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebNet23Online.Models.DelightBistro
{
    public class CreateFoodItemViewModel
    {
        // Тут минимальное количество данных
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImgURL { get; set; }

        // Свойства для базы данных
        public int? MenuId { get; set; }
        public List<SelectList> Menu { get; set; } = new();
    }
}
