namespace WebNet23Online.Models.DelightBistro
{
    public class FoodItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string URL { get; set; }
        public string menuType { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
