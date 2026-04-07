
using WebNet23Online.Services.Interfaces;
using WebNet23Online.Models.LittleLemon;

namespace WebNet23Online.Services
{
    public class LittleLemonMenuService : ILittleLemonMenuService
    {
        public List<LittleLemonMenuCardsViewModel> GetMenuItems(string category)
        {
            var menuItems = new List<LittleLemonMenuCardsViewModel>();
            menuItems.Add(new LittleLemonMenuCardsViewModel
            {
                Name = "Greek salad",
                Price = 12.99M,
                Description = "The famous greek salad of crispy lettuce, peppers, olives and our Chicago style feta cheese, garnished with crunchy garlic and rosemary croutons.",
                ImageUrl = "/images/little-lemon/images/greek-salad-b.jpg",
                Category = "Lunch"
            });
            menuItems.Add(new LittleLemonMenuCardsViewModel
            {
                Name = "Bruschetta",
                Price = 5.99M,
                Description = "Our Bruschetta is made from grilled bread that has been smeared with garlic and seasoned with salt and olive oil.",
                ImageUrl = "/images/little-lemon/images/Italian-Bruschetta-Recipe.jpg",
                Category = "Specials"
            });
            menuItems.Add(new LittleLemonMenuCardsViewModel
            {
                Name = "Lemon dessert",
                Price = 5M,
                Description = "This comes straight from grandma's recipe book, every last ingredient has been added with love.",
                ImageUrl = "/images/little-lemon/images/lemon-dessert.jpg",
                Category = "Desserts"
            });
            menuItems.Add(new LittleLemonMenuCardsViewModel
            {
                Name = "Cheese Sandwich",
                Price = 8M,
                Description = "A classic sandwich made with cheese, bread, and a little bit of love.",
                ImageUrl = "/images/little-lemon/images/sandwich.jpg",
                Category = "Lunch"
            });
            menuItems.Add(new LittleLemonMenuCardsViewModel
            {
                Name = "Zesty lemonade",
                Price = 3.5M,
                Description = "Our delicious cold tangy Lemonade is a favourite with our customers",
                ImageUrl = "/images/little-lemon/images/zesty.jpg",
                Category = "Drinks"
            });
            menuItems.Add(new LittleLemonMenuCardsViewModel
            {
                Name = "Caesar Salad",
                Price = 12M,
                Description = "Served with roman lettuce, parmesan cheese, bacon and our homemade croutons and Caesar dressing.",
                ImageUrl = "/images/little-lemon/images/caesar-salad.jpg",
                Category = "Lunch"
            });
            menuItems.Add(new LittleLemonMenuCardsViewModel
            {
                Name = "Moroccan Tagine",
                Price = 15M,
                Description = "A tender lamb stew with potatoes,gren peas, carrots,roasted tomatoes and Morroccan couscous",
                ImageUrl = "/images/little-lemon/images/tagine.jpg",
                Category = "Lunch"
            });
            var filteredMenuItems = string.IsNullOrEmpty(category)
                ? menuItems.ToList()
                : menuItems.Where(item => item.Category == category)
                .ToList();
            return filteredMenuItems.Count == 0 
                ? menuItems.ToList() 
                : filteredMenuItems;
        }
    }
}
