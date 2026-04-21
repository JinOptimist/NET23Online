using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.LittleLemon;
using WebNet23Online.Services.Interfaces;
using WebNet23Online.Services.Interfaces.LittleLemon;

namespace WebNet23Online.Controllers
{
    public class LittleLemonController : Controller
    {
        private ILittleLemonMenuService _littleLemonMenuService;
        private ILittleLemonTestimonialService _littleLemonTestimonialService;
        private ILittleLemonSubscribeService _littleLemonSubscribeService;
        private ILittleLemonReservationService _littleLemonReservationService;

        public LittleLemonController(ILittleLemonMenuService littleLemonMenuService,
                                     ILittleLemonTestimonialService littleLemonTestimonialService,
                                     ILittleLemonSubscribeService littleLemonSubscribeService,
                                     ILittleLemonReservationService littleLemonReservationService)
        {
            _littleLemonMenuService = littleLemonMenuService;
            _littleLemonTestimonialService = littleLemonTestimonialService;
            _littleLemonSubscribeService = littleLemonSubscribeService;
            _littleLemonReservationService = littleLemonReservationService;
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
        public IActionResult Reservation(int guestId)
        {
            var hero = new LittleLemonHeroSectionViewModel
            {
                CallToActionHref = (Url.Action("Index", "LittleLemon") + "#menu") ?? "/LittleLemon/Index#menu",
                CallToActionText = "Order For Delivery",
                HeroImageUrl = "/images/little-lemon/images/restauranfood.jpg",
                HeroImageAlt = "Signature Mediterranean platter at Little Lemon"
            };
            var reservation = new LittleLemonReservationViewModel
            {
                GuestId = guestId 
            };
            var pageModel = new LittleLemonReservationPageViewModel
            {
                Hero = hero,
                Reservation = reservation
            };

            return View(pageModel);
        }
        [HttpPost]
        public IActionResult Reservation(LittleLemonReservationViewModel viewModel )
        {
            var reservationId = _littleLemonReservationService.CreateReservation(viewModel);
            return RedirectToAction(nameof(Confirmation), new { reservationId });

        }

        [HttpPost]
        public IActionResult CreateGuest(string guestName)
        {
                var guestId = _littleLemonReservationService.CreateGuest(guestName);
                
                return RedirectToAction(nameof(Reservation), new { guestId });
            
        }

        [HttpPost]
        public IActionResult LinkReservationToGuest(int reservationId, int guestId)
        {
            var isLinked = _littleLemonReservationService.LinkReservationToGuest(reservationId, guestId);
            if (!isLinked)
            {
                return RedirectToAction(nameof(Reservation));
            }

            return RedirectToAction(nameof(Confirmation), new { reservationId });
        }

        public IActionResult Confirmation(int reservationId)
        {
            var reservation = _littleLemonReservationService.GetReservationViewModelById(reservationId);
            if (reservation == null)
            {
                return RedirectToAction(nameof(Reservation));
            }
            var hero = new LittleLemonHeroSectionViewModel
            {
                CallToActionHref = (Url.Action("Index", "LittleLemon") + "#menu") ?? "/LittleLemon/Index#menu",
                CallToActionText = "Order For Delivery",
                HeroImageUrl = "/images/little-lemon/images/restauranfood.jpg",
                HeroImageAlt = "Signature Mediterranean platter at Little Lemon"
            };
            var pageModel = new LittleLemonConfirmationViewModel
            {
                Hero = hero,
                Reservation = reservation,
            };
            return View(pageModel);
        }
    }
}
