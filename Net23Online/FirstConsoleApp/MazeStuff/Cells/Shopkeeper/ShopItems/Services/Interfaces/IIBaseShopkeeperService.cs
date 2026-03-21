using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Services.Interfaces
{
    internal interface IIBaseShopkeeperService : IBaseShopItem
    {
        int UnitPrice { get; }
    }
}