using WebNet23Online.Models.JapaneseDomesticMarket;

namespace WebNet23Online.Services.Interfaces
{
    public interface IJapaneseDomesticMarketGenerator
    {
        List<JapaneseDomesticMarketViewModels> GenerateJDMCarsItems();
        void AddJDMItem(JapaneseDomesticMarketViewModels _jdmItems);
    }
}