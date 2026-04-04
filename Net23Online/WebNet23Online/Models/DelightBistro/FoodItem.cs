namespace WebNet23Online.Models.DelightBistro
{
    public class FoodItem
    {
        public string Name { get; set; }
        public int Price { get; set; }
        public string ImgURL { get; set; }
        public string MenuType { get; set; }
        public List<string> Ingredients { get; set; }
    }
}
