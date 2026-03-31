namespace WebNet23Online.Models.DelightBistro
{
    public class MenuTypeViewModel
    {
        public string MenuType { get; set; }
        public List<FoodItem> Items { get; set; }


        public List<FoodItem> GetItems()
        {
            var Items = new List<FoodItem>
            {
                new FoodItem
                {
                     Name = "Tom Yum Talay",
                     Price = 20,
                     URL= "/images/delight-bistro/TomYumTalay.jpg",
                     menuType ="Супы",
                     Ingredients= new List<string>
                     {
                         "Креветки",
                         "Шампиньоны",
                         "Лайм",
                         "Паста",
                         "Помидоры",
                         "Перец чили"
                     }
                }

            };
            return Items;

        }

    }
}
