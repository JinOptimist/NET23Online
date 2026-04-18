using WebNet23Online.Data.Models;

namespace WebNet23Online.Models.DelightBistro
{
    public class IngredientViewModel : BaseModel
    {
        // Создаем только имя, добавить создание нужного количества ингред
        // по строке разделяя строку по запятой
        public string Name { get; set; }
    }
}
