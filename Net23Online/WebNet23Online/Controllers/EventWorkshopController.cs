using Microsoft.AspNetCore.Mvc;
using WebNet23Online.Models.AnimeGirl;
using WebNet23Online.Models.EventWorkshop;
using WebNet23Online.Models.Steam;
using WebNet23Online.Services.EventWorkshop.Interfaces;
namespace WebNet23Online.Controllers
{
    public class EventWorkshopController : Controller
    {
        public IEventService eventService { get; set; }
        EventWorkshopController()
        {
            
        }
        public IActionResult Index(EventCategory? typeEvent) 
        {
            var selectedViewModels = new List<EventInfoViewModel>();
            if(!typeEvent.HasValue)
            {
                selectedViewModels = Events.ToList();
            }
            else
            {
                selectedViewModels = Events
                    .Where(x => x.Category == typeEvent)
                    .ToList();
            }

            return View(selectedViewModels);
        }

        [HttpGet]
        public IActionResult BuilderEvent()
        {
            return View();
        }

        [HttpPost]
        public IActionResult BuilderEvent(EventInfoViewModel newEvent)
        {
            Events.Add(newEvent);
            return RedirectToAction(nameof(EventWorkshopController.Index));
        }
    }
}
