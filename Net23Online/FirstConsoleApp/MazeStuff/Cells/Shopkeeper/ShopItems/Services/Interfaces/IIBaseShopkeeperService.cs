using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services.Interfaces
{
    public interface IIBaseShopkeeperService : IBaseShopItem
    {
        int UnitPrice { get; }
    }
}