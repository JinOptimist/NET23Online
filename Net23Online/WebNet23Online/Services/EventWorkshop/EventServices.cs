using WebNet23Online.Models.EventWorkshop;
using WebNet23Online.Services.EventWorkshop.Interfaces;

namespace WebNet23Online.Services.EventWorkshop
{
    public class EventServices : IEventService
    {
        public List<EventInfoViewModel> Events { get; set; }
        public EventServices() 
        {
            Events = new List<EventInfoViewModel>();
        }
    }
}
