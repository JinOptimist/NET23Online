using FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.Interfaces;

namespace FirstConsoleApp.MazeStuff.Cells.Shopkeeper.ShopItems.TradeGoods.Interfaces
{
    internal interface IBaseTradeGoods : IBaseShopItem
    {
        int Count { get; }
        int UnitPrice { get; }
    }
}