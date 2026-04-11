using WebNet23Online.Models.EventWorkshop;

namespace WebNet23Online.Services.EventWorkshop.Interfaces
{
    public interface IEventWorkshopGenerator
    {
        List<EventInfoViewModel> GenerateList();
    }
}