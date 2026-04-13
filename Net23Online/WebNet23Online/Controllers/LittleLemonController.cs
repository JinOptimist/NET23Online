using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.LittleLemon;
using WebNet23Online.Services.Interfaces;
using WebNet23Online.Data;
using WebNet23Online.Data.Models;

namespace WebNet23Online.Controllers
{
    public class LittleLemonController : Controller
    {
        private ILittleLemonMenuService _littleLemonMenuService;
        private ILittleLemonTestimonialService _littleLemonTestimonialService;
        private ILittleLemonSubscribeService _littleLemonSubscribeService;

        private WebContext _webContext;
        public LittleLemonController(ILittleLemonMenuService littleLemonMenuService,
                                     ILittleLemonTestimonialService littleLemonTestimonialService,
                                     ILittleLemonSubscribeService littleLemonSubscribeService,
                                     WebContext webContext )
        {
            _littleLemonMenuService = littleLemonMenuService;
            _littleLemonTestimonialService = littleLemonTestimonialService;
            _littleLemonSubscribeService = littleLemonSubscribeService;
            _webContext = webContext;
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
        [HttpGet]
        public IActionResult Reservation()
        {
            var hero = new LittleLemonHeroSectionViewModel
            {
                CallToActionHref = (Url.Action("Index", "LittleLemon") + "#menu") ?? "/LittleLemon/Index#menu",
                CallToActionText = "Order For Delivery",
                HeroImageUrl = "/images/little-lemon/images/restauranfood.jpg",
                HeroImageAlt = "Signature Mediterranean platter at Little Lemon"
            };

            var lastReservation = _webContext.littleLemonDatas.FirstOrDefault();
            var pageModel = new LittleLemonReservationPageViewModel
            {
                Hero = hero,
                Reservation = lastReservation
            };

            return View(pageModel);
        }
        [HttpPost]
        public IActionResult Reservation(LittleLemonReservationViewModel viewModel )
        {
            var littleLemonData = new LittleLemonData
            {
                NumberOfGuests = viewModel.NumberOfGuests,
                SeatingPreference = viewModel.SeatingPreference,
                AvailableTimesOnly = viewModel.AvailableTime,
                ReservationDateOnly = viewModel.ReservationDateOnly,
                Occasion = viewModel.Occasion,
                UserComments = viewModel.UserComments,
                UserName = viewModel.UserName,
            };
            _webContext.littleLemonDatas.Add( littleLemonData );
            _webContext.SaveChanges();
            return RedirectToAction(nameof(Confirmation),new { reservationId = littleLemonData.Id });

        }
        public IActionResult Confirmation(int reservationId)
        {
            var reservation = _webContext.littleLemonDatas.Find(reservationId);
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
