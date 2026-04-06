using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.LittleLemon;

namespace WebNet23Online.Controllers
{
    public class LittleLemonController : Controller
    {

        public IActionResult Index(string category)
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
            menuItems = filteredMenuItems.Count == 0 ? menuItems.ToList() : filteredMenuItems;

            var testimonials = new List<LittleLemonTestimonialViewModel>
            {
                new LittleLemonTestimonialViewModel
                {
                    StarRating = 5,
                    UserPhotoUrl = "/images/little-lemon/images/user-1.png",
                    UserPhotoAlt = "Testimonial 1",
                    AuthorDisplayName = "Jon Do",
                    AuthorNickName = "Johnny_utah",
                    Quote = "We had such a great time celebrating my grandmothers birthday!"
                },
                new LittleLemonTestimonialViewModel
                {
                    StarRating = 5,
                    UserPhotoUrl = "/images/little-lemon/images/user-2.png",
                    UserPhotoAlt = "Testimonial 2",
                    AuthorDisplayName = "Naomi Noah",
                    AuthorNickName = "Naomi88-noa",
                    Quote = "Such a chilled out atmosphere - love it!"
                },
                new LittleLemonTestimonialViewModel
                {
                    StarRating = 4,
                    UserPhotoUrl = "/images/little-lemon/images/user-3.png",
                    UserPhotoAlt = "Testimonial 3",
                    AuthorDisplayName = "Joni Sou",
                    AuthorNickName = "Sou_dark",
                    Quote = "Best Feta Salad in town. Flawless everytime!"
                },
                new LittleLemonTestimonialViewModel
                {
                    StarRating = 5,
                    UserPhotoUrl = "/images/little-lemon/images/user-4.png",
                    UserPhotoAlt = "Testimonial 4",
                    AuthorDisplayName = "Sara Lopez",
                    AuthorNickName = "Sara72",
                    Quote = "Seriously cannot stop thinking about the Turkish Mac n' Cheese!!"
                }
            };
            var hero = new LittleLemonHeroSectionViewModel
            {
                CallToActionHref = Url.Action("Reservation", "LittleLemon"),
                CallToActionText = "Reserve a Table",
                HeroImageUrl = "/images/little-lemon/images/restauranfood.jpg",
                HeroImageAlt = "Signature Mediterranean platter at Little Lemon"
            };

            var pageModel = new LittleLemonIndexPageViewModel
            {
                Hero = hero,
                MenuItems = menuItems,
                Testimonials = testimonials
            };
            return View(pageModel);
        }

        public IActionResult Reservation()
        {
            var hero = new LittleLemonHeroSectionViewModel
            {
                CallToActionHref = (Url.Action("Index", "LittleLemon") + "#menu"),
                CallToActionText = "Order For Delivery",
                HeroImageUrl = "/images/little-lemon/images/restauranfood.jpg",
                HeroImageAlt = "Signature Mediterranean platter at Little Lemon"
            };
            return View(hero);
        }
        [HttpGet]
        public IActionResult Subscribe()
        {
            return RedirectToAction("index");
        }

        [HttpPost]
        public IActionResult Subscribe(LittleLemonSubscribeViewModel model)
        {
            var message = SubscribeMessage(model.Email);
            TempData[LittleLemonSubscribeViewModel.MessageKey] = message;
            return LocalRedirect(model.ReturnUrl);

        }

        private bool IsRegistered(string email)
        {
            var registeredEmails = new List<string>
            {
                "alice@gmail.com",
                "bob@example.com"
            };
            if (registeredEmails
                .Contains(email))
            {
                return true;
            }

            return false;
        }
        private string SubscribeMessage(string email)
        {
            var name = email.Split('@')[0]
                .Split('.')[0];
            if (IsRegistered(email))
            {
                return $"{name}, You are already with us!";
            }
            return $"Thanks {name} for subscribe!";
        }

    }
}
