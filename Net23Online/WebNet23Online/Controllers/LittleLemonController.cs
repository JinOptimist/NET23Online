using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.LittleLemon;
using WebNet23Online.Services.Interfaces;

namespace WebNet23Online.Controllers
{
    public class LittleLemonController : Controller
    {
        private ILittleLemonMenuService _littleLemonMenuService;
        private ILittleLemonTestimonialService _littleLemonTestimonialService;
        private ILittleLemonSubscribeService _littleLemonSubscribeService;
        public LittleLemonController(ILittleLemonMenuService littleLemonMenuService, ILittleLemonTestimonialService littleLemonTestimonialService, ILittleLemonSubscribeService littleLemonSubscribeService)
        {
            _littleLemonMenuService = littleLemonMenuService;
            _littleLemonTestimonialService = littleLemonTestimonialService;
            _littleLemonSubscribeService = littleLemonSubscribeService;
        }

        public IActionResult Index(string category)
        {
            var menuItems = _littleLemonMenuService.GetMenuItems(category);

            var testimonials = _littleLemonTestimonialService.GetTestimonials();
            var hero = new LittleLemonHeroSectionViewModel
            {
                CallToActionHref = Url.Action("Reservation", "LittleLemon") ?? "/LittleLemon/Reservation",
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
                CallToActionHref = (Url.Action("Index", "LittleLemon") + "#menu")?? "/LittleLemon/Index#menu",
                CallToActionText = "Order For Delivery",
                HeroImageUrl = "/images/little-lemon/images/restauranfood.jpg",
                HeroImageAlt = "Signature Mediterranean platter at Little Lemon"
            };
            return View(hero);
        }
        [HttpGet]
        public IActionResult Subscribe()
        {
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        public IActionResult Subscribe(LittleLemonSubscribeViewModel model)
        {
            var message = _littleLemonSubscribeService.GetSubscribeMessage(model.Email);
            TempData[LittleLemonSubscribeViewModel.MESSAGE_KEY] = message;
            if (Url.IsLocalUrl(model.ReturnUrl))
            {
                return LocalRedirect(model.ReturnUrl);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
