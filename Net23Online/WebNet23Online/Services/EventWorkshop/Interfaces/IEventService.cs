using WebNet23Online.Models.EventWorkshop;

namespace WebNet23Online.Services.EventWorkshop.Interfaces
{
    public interface IEventService
    {
        List<EventInfoViewModel> Events { get; set; }
    }
}