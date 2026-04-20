
using WebNet23Online.Data.Models.Steam;
using WebNet23Online.Models.Steam;

namespace WebNet23Online.Services.Interfaces
{
    public interface ICatalogService
    {
        CatalogViewModel GetCatalog(CatalogFilterViewModel filter = null);
        SteamHomeViewModel GetGamesForHomePage();
        void AddGame(AddGameViewModel viewModel);
        List<PublisherData> GetPublishers();
        GameData GetGameDetails(int id);
        void UpdateGame(EditGameViewModel viewModel);
    }
}