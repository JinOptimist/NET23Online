using WebNet23Online.Models.LittleLemon;

namespace WebNet23Online.Services.Interfaces
{
    public interface ILittleLemonMenuService
    {
        List<LittleLemonMenuCardsViewModel> GetMenuItems(string category);
    }
}