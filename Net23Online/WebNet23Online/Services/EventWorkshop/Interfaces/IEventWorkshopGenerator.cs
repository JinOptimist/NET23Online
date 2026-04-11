using WebNet23Online.Models.EventWorkshop;

namespace WebNet23Online.Services.EventWorkshop.Interfaces
{
    public interface IEventWorkshopGenerator
    {
        IEventService EventService { get; set; }

        List<EventInfoViewModel> GenerateList();
    }
}