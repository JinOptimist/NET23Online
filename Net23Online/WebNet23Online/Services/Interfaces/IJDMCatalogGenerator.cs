using WebNet23Online.Models.JapaneseDomesticMarket;

namespace WebNet23Online.Services.Interfaces
{
    public interface IJDMCatalogGenerator
    {
        List<JDMCatalogViewModels> GetManufacturerTypeFromJDMItems(List<JapaneseDomesticMarketViewModels> carsJDMItems, string sortManufacturerType);
    }
}
